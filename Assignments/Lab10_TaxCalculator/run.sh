#!/bin/bash

# Written by Joe
# If you do not have bash (or zsh or, something)
# You can invoke cmake as ususal per your system
# See the readme at the root of this repo.

projName=$(pwd | awk -F / '{print $NF}') # Get project name

if [[ $* == *--pack* ]]
then
    git clean -fdX
    mkdir -p _build
    mcs TaxCalculator.cs
    cd _build
    # python ../test.py | sed 's/\x1B\[[0-9;]\{1,\}[A-Za-z]//g' &> results.txt # Pipe the test results to a file (Also strips the color codes with sed)

    # Build the docs
    cp ../*.cs .
    cp ../*.tex .
    cp ../*.png .
	# cp ../*.sty .
	find . -name '*.tex' -exec latexmk --shell-escape -pdf {} \;

    # # Stage and zip
    mkdir -p bin/
    mkdir -p source/
    mv ../*.exe bin/

    cp -r ../* source/
    rm -r source/_build # messy but extglobs are hard

    tar -zcvf $projName.tar.gz bin/ Writeup.pdf source/

    # Give it a nice name
    mv *.pdf TaxCalculator.pdf
else
    mcs TaxCalculator.cs -pkg:gtk-sharp-2.0
    mono TaxCalculator.exe
fi
