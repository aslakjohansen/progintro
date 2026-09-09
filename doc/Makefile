DEMOS = \
	uml-demo.pdf \

TARGETS = \
	document.pdf \
	${DEMOS}

SECONDARY_TARGETS = $(patsubst %.tex,%.pdf,$(wildcard *.tex))

AUTOGEN_DEPS = \
	hlsections.tex \
	figs/dynamic/test-integration.tex \
	exercises/answers.tex \


Aslak\ Johansen\ -\ Introduction\ to\ Programming\ …\ in\ C\#.pdf: all
	cp document.pdf Aslak\ Johansen\ -\ Introduction\ to\ Programming\ …\ in\ C\#.pdf

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch ${AUTOGEN_DEPS} ${SECONDARY_TARGETS} d~ d.aux d.bbl d.bcf d.blg d.idx d.ilg d.ind d.lof d.log d.minted d.out d.run.xml d.toc
	rm    ${AUTOGEN_DEPS} ${SECONDARY_TARGETS} *~ *.aux *.bbl *.bcf *.blg *.idx *.ilg *.ind *.lof *.log *.minted *.out *.run.xml *.toc
	touch exercises
	rm -R exercises


hlsections.tex: ../bin/generate-hl-sections.exs
	../bin/generate-hl-sections.exs > hlsections.tex


figs/dynamic:
	mkdir figs/dynamic

figs/dynamic/test-integration.tex: ../bin/generate-test-integration.exs ../var/test_integration.graphml figs/dynamic
	../bin/generate-test-integration.exs ../var/test_integration.graphml n15-n17-n16-n18,n24-n23-n22-n25,n26-n29-n31-n27,n8-n9-n13-n10-n11-n4,n2-n1-n5-n6-n7,n21-n20-n19 figs/dynamic/test-integration.tex

exercises:
	mkdir exercises

exercises/answers.tex: *.tex ../bin/process-exercises.exs exercises
	../bin/process-exercises.exs contents.tex .

document.pdf: Makefile ${AUTOGEN_DEPS} *.sty *.tex */*.tex references.bib
	lualatex "\newcommand\contentsfile{contents.tex} \input{document.tex}"
	makeindex document.idx
	biber document.bcf
	lualatex "\newcommand\contentsfile{contents.tex} \input{document.tex}"
	lualatex "\newcommand\contentsfile{contents.tex} \input{document.tex}"

# for per-chapter targets
%.pdf: %.tex */*.tex
	lualatex -jobname=$* "\newcommand\contentsfile{$<} \input{document.tex}"

uml-demo.pdf: Makefile uml-demo.tex uml.sty
	lualatex uml-demo.tex

