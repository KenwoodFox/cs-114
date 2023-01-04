#!/bin/python
# Joe 2022


import fileinput
import shutil
import sys
import os

from glob import glob


src = "0.0_Template"

print("Wizzard for making a new challenge project from template\n --Joe\n\n")

projName = input("Enter project Name   (Ex. HelloWorld ): ")
projNum = input("Enter project Number (Ex. 2.19)       : ")

# Destination path
dest = f"{projNum}_{projName}/"

# Copy all files
shutil.copytree(src, dest)

# All files
newFiles = [y for x in os.walk(dest) for y in glob(os.path.join(x[0], "*.*"))]

for file in newFiles:
    print(f"Replacing text in {file}")
    with open(file, "r") as curFile:
        data = curFile.read()  # Contents of file

        # Replacements
        data = data.replace("~~name~~", projName)
        data = data.replace("~~number~~", projNum)

    with open(file, "w") as curFile:
        # Writeback out
        curFile.write(data)

print("Done.")
