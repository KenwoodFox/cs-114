
all: build run

build: Adding.cs
	mcs Adding.cs

pack: # Packs everything into a file to submit
	mkdir -p _staging
	cp Makefile *.cs *.md _staging
	tar -zcvf _staging/Adding.tar.gz _staging/*

clean:
	git clean -fdX

run: Adding.exe
	mono Adding.exe
