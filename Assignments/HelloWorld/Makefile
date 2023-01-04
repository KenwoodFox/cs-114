
all: build run

build: HelloWorld.cs
	mcs HelloWorld.cs

pack: # Packs everything into a file to submit
	mkdir -p _staging
	cp Makefile *.cs *.md _staging
	tar -zcvf _staging/HelloWorld.tar.gz _staging/*

clean:
	git clean -fdX

run: HelloWorld.exe
	mono HelloWorld.exe
