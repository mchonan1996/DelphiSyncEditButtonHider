# Delphi Sync Edit Button Hider
A simple utility that monitors for the Sync Edit button in Delphi (that causes HUGE slow downs in scrolling performance), and hides it.

---

Have you been using Delphi / C++ Builder / RAD Studio / AppMethod and been having *appauling* scrolling performance whenever you select some text?

The issue is caused by the Sync Edit button that shows up on the left bumper in the Editor. Due to some poor drawing on Embarcadero's part, this causes massive slowdowns on even higher end PCs.

So the mission of this little app is to target the handle of that crappy button and completely obliterate it from existance.

---

Before:
[Imgur](https://i.imgur.com/onEk10l.gifv)

After:
[Imgur](https://i.imgur.com/QLENG7U.gifv)

---
**Please Note:** If you're using CnPack IDE Wizards you will need to disable their Selection Button too or else it will also affect your scrolling. You can disable the Selection Button by navigating to Editor Enhancements in the CnPack options, then unticking the "Show Selection Button when A Block Selected" option under the "Tabset / Button" tab.
![CnPack IDE Wizards Options](https://i.imgur.com/ZIv8D05.png "CnPack IDE Wizards Options")

---
Feel free to contribute and happy coding!
