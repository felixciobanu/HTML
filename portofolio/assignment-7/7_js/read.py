import json
import csv


with open("data/albums.txt") as file:
    les = csv.reader(file, delimiter="\t")
    infoAlbums = []
    for line in les:
        infoA = {}
        infoA["album"] = line[0]
        infoA["Artist"] = line[1]
        infoA["title"] = line[2]
        infoA["image"] = line[3]
        infoAlbums.append(infoA)
    print(infoAlbums)
    print(json.dumps(infoAlbums))
    print(infoAlbums[0]["album"])

    album_id = 1
    new = []
    for e in infoAlbums:
        if e['album'] == str(album_id):
            new.append(e)
        print(e)
    print(new)
with open("data/onceAgain.json", "w") as f:
    json.dump(infoAlbums, f, indent=2)
