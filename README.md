# Introduction til Programming ... in C#

The goal is for this to become a coursebook introducing new BSc students to programming, with a focus on C#.

## Repository Structure

- [bin](bin) Scripts for automation.
- [doc](doc) The code for the book itself.
- [ex](ex) Exercises that are to be included in the book.
- [src](src) Code that is intended to be included in the book.

## Practices

### Screenshots

In order to take consistent screenshorts, first find the window id by running the `xwininfo` command and then clicking on the window:

```console
$ xwininfo | grep id
xwininfo: Window id: 0x1a000f8 "*README.md (~/vcs/git/progintro) - gedit"
  Width: 1354
  Border width: 0
  Override Redirect State: no
```

In this case the window id is `0x1a000f8`. We can now adjust the size of this window using the `xdotool` command:

```console
$ xdotool windowsize 0x1a000f8 800 600
```

