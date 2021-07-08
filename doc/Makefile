TARGETS = \
	document.pdf \

all: ${TARGETS}

clean:
	touch ${TARGETS}
	rm    ${TARGETS}

mrproper: clean
	touch d~
	rm    *~

document.pdf: document.tex
	pdflatex document.tex
	pdflatex document.tex

