# LinkRestorer
Restores Junction Points after Windows Update

Directory links (junction points) from C:\ drive to another drive (e.g. D:\)
often get corrupted by Windows Updates (major updates, service packs).
For example:
"C:\Program Files (x86)\Microsoft SDKs" pointed to "D:\Redirect\Windows SDKs".
Feature update to Windows 10, version 1709 thrashed this link by letting it
point to "C:\Redirect\Windows SDKs" (which doesn't exist). These feature updates
seem to replace all drive letters in links with "C:\".
With LinkRestorer, if you have your junction points all set up, you can make
a snapshot of where they point to, and then after such an update, you can restore
them again.
