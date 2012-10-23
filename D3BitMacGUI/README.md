# D3Bit Mac GUI

This is an attempt to build a Mac GUI for D3Bit.

## Requirements

Installation of Tesseract (using Homebrew http://mxcl.github.com/homebrew/)

```
$ brew install tesseract
```

## Additional Manual Setup Steps

Not certain how to configure MonoDevelop correctly to package these resources in the build correctly.

### Copy the tesseract directory

```
$ cd path/to/D3Bit
$ open D3BitMacGUI/D3BitMacGUI/bin/Debug/D3BitMacGUI.app/Contents/
$ open Release/
```

Copy the directory `tesseract` from Release into the `MonoBundle` directory.

### Create a link to tesseract

```
$ which tesseract
/usr/local/bin/tesseract
$ ln -f /usr/local/bin/tesseract D3BitMacGUI/D3BitMacGUI/bin/Release/D3BitMacGUI.app/Contents/MonoBundle/tesseract/tesseract_mac
```

### Open D3BitMacGUI

```
$ cd path/to/D3Bit
$ open D3BitMacGUI/D3BitMacGUI/bin/Release/D3BitMacGUI.app/Contents/MacOS/D3BitMacGUI
```

## Mac OS X Screen Shots

Command + shift + 4

Hit space bar to switch to window capture mode

Screen shot is saved to Desktop by default

## D3UP Builds

Open the following URL in a web browser to find D3UP build numbers.

```
http://d3up.com/ajax/builds?username=<your username>
```
