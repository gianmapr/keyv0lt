# keyv0lt
A simple keylogger for Windows-based systems.

**Note: this software is only for educational purposes. I take no responsibility for the use of my software by third parties.**

## instructions:
For first you need to open the .cs file with any text editor and go to *line 67*. Here you need to change `"MAIL_SUBJECT"` in a valid subject for the mail. In *line 83* you need to change `"SENDER_MAIL"` in a valid gmail account for use as client for the e-mail from the keylogger (you need also to re-enter it on *line 88* also with the password of the account). For last you need to put the recipient mail overwriting `"RECIPIENT_MAIL"` in *line 84*. The last step is compile it with a C debugger and run it on the victim machine.

## notes
You need to enable **"untrusted apps"** on the Google Account dashboard for the client-mail account.

The most part of antiviruses detects this keylogger as virus. To prevent this, you need to hide it with a **rootkit**.


Developed by gianmapr.
