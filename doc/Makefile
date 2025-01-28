TARGETS = \
	document.pdf \

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~

document.pdf: *.tex
	lualatex document.tex
	lualatex document.tex

