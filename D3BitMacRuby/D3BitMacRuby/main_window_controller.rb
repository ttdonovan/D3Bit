#
#  main_window_controller.rb
#  D3BitMacRuby
#
#  Created by Tanner Donovan on 10/23/12.
#  Copyright 2012 Tanner Donovan. All rights reserved.
#

class MainWindowController < NSWindowController
  attr_accessor :open_button, :item_image_well, :item_text_view, :web_view

  def awakeFromNib
    # FIXME: shouldn't IBOutlest be available in awakFromNib? @web_view is nil. see AppDelegate #applicationDidFinishLaunching
    @web_view.frameLoadDelegate = self
    url = NSURL.alloc.initWithString("http://d3bit.com/c")
    @web_view.mainFrame.loadRequest NSURLRequest.requestWithURL(url)
  end
  
  def press_open_button(sender)
    dialog = NSOpenPanel.openPanel
    
    # display the dialog and process the selected file
    if dialog.runModal == NSFileHandlingPanelOKButton
      # create a task to run 'mono'
      task = NSTask.alloc.init
      task.setLaunchPath('/usr/bin/mono')
      
      # define the arguments for the task
      # TODO: find a better set the path for D3BitMacConsole, can the bin/Release be bundled and included with this D3BitMacRuby?
      arguments = ['/Users/tanner/Workspace/ttdonovan-github/D3Bit/D3BitMacConsole/D3BitMacConsole/bin/Debug/D3BitMacConsole.exe', '--tooltip', dialog.URL.path]
      task.setArguments(arguments)

      # create a file to capture the task standard output
      pipe = NSPipe.pipe
      task.setStandardOutput(pipe)
      file = pipe.fileHandleForReading
      
      # launch the task and read the file output
      task.launch
      string = NSString.alloc.initWithData(file.readDataToEndOfFile, encoding: NSUTF8StringEncoding)
      lines = string.componentsSeparatedByString("\n")
      
      # lines[-2], is the last line empty?
      @item_text_view.insertText(lines[-2])
      
      # TODO: will want to set the image well with the processed image not the screenshot
      @item_image_well.Image = NSImage.alloc.initWithContentsOfURL(dialog.URL)
    end
  end
end
