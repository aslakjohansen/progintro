TARGETS = \
	errorhandling \

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~

errorhandling: errorhandling.c Makefile
	gcc errorhandling.c -o errorhandling
