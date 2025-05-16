TARGETS = \
	document.pdf \

AUTOGEN_DEPS = \
	hlsections.tex \
	exercises/answers.tex \


all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch ${AUTOGEN_DEPS} d~ d.aux d.bbl d.bcf d.blg d.idx d.ilg d.ind d.lof d.log d.out d.run.xml d.toc
	rm    ${AUTOGEN_DEPS} *~ *.aux *.bbl *.bcf *.blg *.idx *.ilg *.ind *.lof *.log *.out *.run.xml *.toc
	touch exercises
	rm -R exercises


hlsections.tex: ../bin/generate-hl-sections.exs
	../bin/generate-hl-sections.exs > hlsections.tex


exercises:
	mkdir exercises

exercises/answers.tex: *.tex ../bin/process-exercises.exs exercises
	../bin/process-exercises.exs document.tex .


document.pdf: Makefile ${AUTOGEN_DEPS} *.sty *.tex */*.tex references.bib
	lualatex document.tex
	makeindex document.idx
	biber document.bcf
	lualatex document.tex
	lualatex document.tex

