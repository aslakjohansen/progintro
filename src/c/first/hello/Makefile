TARGETS = \
	hello

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~

hello: hello.c
	clang hello.c -o hello

