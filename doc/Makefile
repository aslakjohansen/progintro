TARGETS = \
	document.pdf \

AUTOGEN_DEPS = \
	hlsections.tex


all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch ${AUTOGEN_DEPS} d~ d.aux d.log d.out d.toc
	rm    ${AUTOGEN_DEPS} *~ *.aux *.log *.out *.toc


hlsections.tex: ../bin/generate-hl-sections.exs
	../bin/generate-hl-sections.exs > hlsections.tex


document.pdf: Makefile ${AUTOGEN_DEPS} *.tex */*.tex references.bib
	lualatex document.tex
	makeindex document.idx
	biber document.bcf
	lualatex document.tex
	lualatex document.tex

