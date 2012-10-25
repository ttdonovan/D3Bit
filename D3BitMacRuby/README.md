# D3Bit Mac Ruby

## Xcode 4.3 Mac Ruby Compatibility Problem Workaround

```
$ cd /Applications/Xcode.app/Contents/Developer/Tools
$ sudo ln -s /Library/Frameworks/MacRuby.framework/Versions/Current/usr/bin/rb_nibtool
$ sudo xcode-select -switch /Applications/Xcode.app/Contents/Developer
```

See http://lldong.github.com/blog/2012/03/05/xcode-4-dot-3-macruby-compatible-problem-workaround/ for more details.

 