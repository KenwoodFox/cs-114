
all: build run

build: ComparingNums.cs
	mcs ComparingNums.cs

pack: # Packs everything into a file to submit
	mkdir -p _staging
	cp Makefile *.cs *.md _staging
	tar -zcvf _staging/ComparingNums.tar.gz _staging/*

clean:
	git clean -fdX

run: ComparingNums.exe
	mono ComparingNums.exe
