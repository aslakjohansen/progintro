TARGETS = \
	document.pdf \

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~ d.aux d.log d.out d.toc
	rm    *~ *.aux *.log *.out *.toc

document.pdf: Makefile *.tex
	lualatex document.tex
	makeindex document.idx
	lualatex document.tex
	lualatex document.tex

