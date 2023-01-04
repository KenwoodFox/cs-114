
all: build run

build: ~~name~~.cs
	mcs ~~name~~.cs

pack: # Packs everything into a file to submit
	mkdir -p _staging
	cp Makefile *.cs *.md _staging
	tar -zcvf _staging/~~name~~.tar.gz _staging/*

clean:
	git clean -fdX

run: ~~name~~.exe
	mono ~~name~~.exe
