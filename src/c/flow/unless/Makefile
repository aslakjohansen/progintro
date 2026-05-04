TARGETS = \
	unless


all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~


unless: unless.c
	gcc unless.c -o unless

