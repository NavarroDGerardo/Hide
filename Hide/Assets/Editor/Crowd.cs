using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class Crowd : MonoBehaviour
{
    List<List<Vector3>> positions;

    public GameObject prefab;
    public int numberPeople;
    private GameObject[] people;
    public float timerToUpdate = 5.0f;
    public float timer;
    public float dt;

    struct Data
    {
        public Vector3[] positions;

        public Data(Vector3[] _positions)
        {
            positions = _positions;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        people = new GameObject[numberPeople];
        for(int i = 0; i < people.Length; i++)
        {
            people[i] = Instantiate(prefab, transform.position, Quaternion.identity);
        }

        positions = new List<List<Vector3>>();

        Vector3 pos = transform.localPosition;
        string json = EditorJsonUtility.ToJson(pos);
        //string call = "WAAAASAAAAP";
        StartCoroutine(SendData(json));
        timer = timerToUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        dt = 1.0f - (timer / timerToUpdate);

        if (timer < 0)
        {
            timer = timerToUpdate;
            Vector3 fakepos = transform.position;
            string json = EditorJsonUtility.ToJson(fakepos);
            StartCoroutine(SendData(json));
        }

        if (positions.Count > 1)
        {
            for (int s = 0; s < people.Length; s++)
            {
                List<Vector3> last = positions[positions.Count - 1];
                List<Vector3> prevLast = positions[positions.Count - 2];
                Vector3 interpolated = Vector3.Lerp(prevLast[s], last[s], dt);
                people[s].transform.localPosition = interpolated;

                Vector3 dir = last[s] - prevLast[s];
                people[s].transform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }

    IEnumerator SendData(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("bundle", "the data");
        string url = "http://localhost:8585";
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(data);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-type", "application/json");

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                List<Vector3> newPositions = new List<Vector3>();
                string txt = www.downloadHandler.text.Replace('\'', '\"');
                txt = txt.TrimStart('"', '{', 'd', 'a', 't', 'a', ':', '[');
                txt = "{\"" + txt;
                txt = txt.TrimEnd(']', '}');
                txt = txt + '}';
                //Debug.Log(txt);
                string[] strs = txt.Split(new string[] { "}, {" }, StringSplitOptions.None);
                for (int i = 0; i < strs.Length; i++)
                {
                    strs[i] = strs[i].Trim();
                    if (i == 0) strs[i] = strs[i] + '}';
                    else if (i == strs.Length - 1) strs[i] = '{' + strs[i];
                    else strs[i] = '{' + strs[i] + '}';
                    Vector3 test = JsonUtility.FromJson<Vector3>(strs[i]);
                    newPositions.Add(test);
                }

                List<Vector3> poss = new List<Vector3>();
                for (int i = 0; i < people.Length; i++)
                {
                    poss.Add(newPositions[i]);
                }

                positions.Add(poss);
            }
        }
    }
}
