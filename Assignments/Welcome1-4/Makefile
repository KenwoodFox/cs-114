
all: build run

build: stringInterpolation.cs
	mcs stringInterpolation.cs

pack: # Packs everything into a file to submit
	mkdir -p _staging
	cp Makefile *.cs *.md _staging
	tar -zcvf _staging/stringInterpolation.tar.gz _staging/*

clean:
	git clean -fdX

run: stringInterpolation.exe
	mono stringInterpolation.exe
