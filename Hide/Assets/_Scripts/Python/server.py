from http.server import BaseHTTPRequestHandler, HTTPServer
import logging
import json

import numpy as np
from boid import Boid
import random

width = 633
height = 697

flock = [Boid(random.uniform(-64.0, 569.0), random.uniform(133.0, 830), width, height) for _ in range(20)]

def updatePosition():
    global flock
    positions = []
    for boid in flock:
        boid.apply_behaviour(flock)
        boid.update()
        pos = boid.edges()
        positions.append(pos)
    return positions

def positionsToJSON(ps):
    posDICT = []
    for p in ps:
        pos = {
            "x" : p[0],
            "z" : p[1],
            "y" : p[2]
        }
        posDICT.append(pos)
    return json.dumps(posDICT)


class Server(BaseHTTPRequestHandler):
    def _set_response(self):
        self.send_response(200)
        self.send_header('Content-type', 'text/html')
        self.end_headers()

    def do_GET(self):
        logging.info("GET request,\nPath: %s\nHeaders:\n%s\n", str(self.path), str(self.headers))
        self._set_response()
        self.wfile.write("GET request for {}".format(self.path).encode('utf-8'))
        
    def do_POST(self):
        content_length = int(self.headers['Content-Length'])
        #post_data = self.rfile.read(content_length)
        post_data = json.loads(self.rfile.read(content_length))
        #logging.info("POST request,\nPath: %s\nHeaders:\n%s\n\nBody:\n%s\n", str(self.path), str(self.headers), post_data.decode('utf-8'))
        logging.info("POST request,\nPath: %s\nHeaders:\n%s\n\nBody:\n%s\n", str(self.path), str(self.headers), json.dumps(post_data))

        # x = post_data['x'] * 10
        # y = post_data['y']
        # z = post_data['z'] * 10

        # position = {"x" : x, "y" : y, "z" : z}

        positions = updatePosition()
        self._set_response()
        resp = "{\"data\":" + positionsToJSON(positions) + "}"
        self.wfile.write(resp.encode('utf-8'))

def run(server_class=HTTPServer, handler_class=Server, port=8585):
    logging.basicConfig(level=logging.INFO)
    server_address = ('', port)
    httpd =server_class(server_address, handler_class)
    logging.info("Starting httpd...\n")
    try:
        httpd.serve_forever()
    except KeyboardInterrupt:
        pass
    httpd.server_close()
    logging.ingo("Stopping http...\n")

if __name__ == '__main__':
    from sys import argv

    if len(argv) == 2:
        run(por=int(argv[1]))
    else:
            run()