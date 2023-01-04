
all: build run

build: hello.cs
	csc hello.cs -r:System.Windows.Forms.dll -r:System.Drawing.dll

clean:
	git clean -fdX

run: hello.exe
	mono hello.exe
