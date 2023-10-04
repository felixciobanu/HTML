"""
Assignment #7: AJAX
"""
import json
from flask import Flask, request, g
import csv


app = Flask(__name__)


class Albums:
    """Class representing a collection of albums."""

    def __init__(self, albums_file, tracks_file):
        self.__albums = []
        self.__tracks = []
        self.__load_albums(albums_file)
        self.__load_tracks(tracks_file)

    def __load_albums(self, albums_file):
        """Loads a list of albums from a file."""
        with open(albums_file) as file:
            les = csv.reader(file, delimiter="\t")
            for line in les:
                infoA = {}
                infoA["albumNr"] = line[0]
                infoA["Artist"] = line[1]
                infoA["title"] = line[2]
                infoA["bilde"] = line[3]
                self.__albums.append(infoA)
        # TODO complete
        pass

    def __load_tracks(self, tracks_file):
        """Loads a list of tracks from a file."""
        with open(tracks_file) as file:
            les2 = csv.reader(file, delimiter="\t")
            for line in les2:
                infoT = {}
                infoT["albumNr"] = line[0]
                infoT["song"] = line[1]
                infoT["durationSong"] = line[2]
                self.__tracks.append(infoT)
        # TODO complete
        pass

    def get_albums(self):
        """Returns a list of all albums, with album_id, artist and title."""
        # TODO complete
        return json.dumps(self.__albums)

    def get_album(self, album_id):
        """Returns all details of an album."""
        # TODO complete
        new = []
        for e in self.__tracks:
            if int(e['albumNr']) == int(album_id):
                print(f"{int(e['albumNr'])} == {int(album_id)}")
                new.append(e)
        print(new)

        return json.dumps(new)


# the Albums class is instantiated and stored in a config variable
# it's not the cleanest thing ever, but makes sure that the we load the text files only once


# app.config["albums"] = Albums("data/albums.txt", "data/tracks.txt")
app.config["albums"] = Albums("C:/Users/felix/PycharmProjects/pythonProject1/assignment-7/7_js/data/albums.txt",
                              "C:/Users/felix/PycharmProjects/pythonProject1/assignment-7/7_js/data/tracks.txt")


@app.route("/albums")
def albums():
    """Returns a list of albums (with album_id, author, and title) in JSON."""
    albums = app.config["albums"]
    # TODO complete (return albums.get_albums() in JSON format)
    return albums.get_albums()


@app.route("/albuminfo")
def albuminfo():
    albums = app.config["albums"]
    album_id = request.args.get("album_id", None)
    if album_id:
        # TODO complete (return albums.get_album(album_id) in JSON format)
        return albums.get_album(album_id)
    return ""


@app.route("/sample")
def sample():
    return app.send_static_file("index_static.html")


@app.route("/")
def index():
    return app.send_static_file("index.html")


if __name__ == "__main__":
    app.run()
