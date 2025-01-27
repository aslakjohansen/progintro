TARGETS = \
	document.pdf \

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~

document.pdf: document.tex contents/*/*.tex
	lualatex document.tex
	lualatex document.tex

