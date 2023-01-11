#!/bin/python
# Joe 2022


import fileinput
import shutil
import sys
import os

from glob import glob


src = "0.0_Template"

print(
    """
 ____            _           _   
|  _ \ _ __ ___ (_) ___  ___| |_ 
| |_) | '__/ _ \| |/ _ \/ __| __|
|  __/| | | (_) | |  __/ (__| |_ 
|_|   |_|  \___// |\___|\___|\__|
              |__/               
  ____                           _             
 / ___| ___ _ __   ___ _ __ __ _| |_ ___  _ __ 
| |  _ / _ \ '_ \ / _ \ '__/ _` | __/ _ \| '__|
| |_| |  __/ | | |  __/ | | (_| | || (_) | |   
 \____|\___|_| |_|\___|_|  \__,_|\__\___/|_|

A wizard for making a new challenge project from template\n --Joe\n\n"""
)

projName = str(input("Enter project Name   (Ex. HelloWorld ): "))
projNum = str(input("Enter project Number (Ex. 2.19)       : "))

# Destination path
if len(projNum) != 0:
    dest = f"{projNum}_{projName}/"
else:
    dest = f"{projName}/"

# Copy all files
shutil.copytree(src, dest)

# Rename cs file
os.rename(f"{dest}/hello.cs", f"{dest}/{projName}.cs")

# All files
newFiles = [y for x in os.walk(dest) for y in glob(os.path.join(x[0], "*"))]

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
