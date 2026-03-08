TARGETS = \
	define.txt \
	ifdef.txt \

CFLAGS = -O0 -Wpedantic

#####################################################################
####################################################### major targets

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~

#####################################################################
####################################################### minor targets

define.txt: define.c
	gcc ${CFLAGS} -DMULTIPLIER=3 define.c -o define
	./define > define.txt

ifdef.txt: ifdef.c
	gcc ${CFLAGS} ifdef.c -o ifdef
	./ifdef > ifdef.txt
	gcc ${CFLAGS} -DBENCHMARK ifdef.c -o ifdef_test
	./ifdef_test > ifdef_test.txt

%.txt: %.c
	gcc ${CFLAGS} $*.c -o $*
	./$*  > $*.txt

################################################################# EOF
#####################################################################

