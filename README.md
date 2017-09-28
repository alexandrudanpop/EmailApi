# EmailApi
Requirements: dotnet core 2.0

1) Create a gmail account and set Allow less secure apps: ON 
https://myaccount.google.com/lesssecureapps 
2) Edit src\EmailApi\appsettings.json and put your email and password
  "User": "yourEmail@gmail.com",
  "Password": "yourSecretPassword"

3) dotnet restore
4) dotnet run

Open terminal and execute:
<pre style='color:#000000;background:#ffffff;'>curl <span style='color:#808030; '>-</span>X POST \
<span style='color:#e34adc; '>&#xa0;&#xa0;http:</span><span style='color:#696969; '>//localhost:5000/api/email \</span>
  <span style='color:#808030; '>-</span>H <span style='color:#ffffff; background:#dd0000; font-weight:bold; font-style:italic; '>'cache-control: no-cache'</span> \
  <span style='color:#808030; '>-</span>H <span style='color:#ffffff; background:#dd0000; font-weight:bold; font-style:italic; '>'content-type: application/json'</span> \
  <span style='color:#808030; '>-</span>d '<span style='color:#800080; '>{</span>
	<span style='color:#800000; '>"</span><span style='color:#0000e6; '>subject</span><span style='color:#800000; '>"</span><span style='color:#800080; '>:</span> <span style='color:#800000; '>"</span><span style='color:#0000e6; '>application error</span><span style='color:#800000; '>"</span><span style='color:#808030; '>,</span>
	<span style='color:#800000; '>"</span><span style='color:#0000e6; '>toEmailAddress</span><span style='color:#800000; '>"</span><span style='color:#800080; '>:</span> <span style='color:#800000; '>"</span><span style='color:#0000e6; '>johndoe@gmail.com</span><span style='color:#800000; '>"</span><span style='color:#808030; '>,</span>
	<span style='color:#800000; '>"</span><span style='color:#0000e6; '>body</span><span style='color:#800000; '>"</span><span style='color:#800080; '>:</span> <span style='color:#800000; '>"</span><span style='color:#0000e6; '>	&lt;h2> App Error &lt;/h2>&lt;p> There has been an error processing your Request &lt;/p>&lt;p> Internal Error.. &lt;/p></span><span style='color:#800000; '>"</span><span style='color:#808030; '>,</span>
	<span style='color:#800000; '>"</span><span style='color:#0000e6; '>cc</span><span style='color:#800000; '>"</span><span style='color:#800080; '>:</span> <span style='color:#808030; '>[</span><span style='color:#800000; '>"</span><span style='color:#0000e6; '>bob@bob.com</span><span style='color:#800000; '>"</span><span style='color:#808030; '>,</span> <span style='color:#800000; '>"</span><span style='color:#0000e6; '>tim@corporate.com</span><span style='color:#800000; '>"</span><span style='color:#808030; '>]</span>
<span style='color:#800080; '>}</span>'
</pre>

Postman example:
<pre style='color:#000000;background:#ffffff;'><span style='color:#696969; '>{</span>
<span style='color:#696969; '>	"subject": "application error",</span>
<span style='color:#696969; '>	"toEmailAddress": "</span><span style='color:#7144c4; '>johndoe@gmail.com</span><span style='color:#696969; '>",</span>
<span style='color:#696969; '>	"body": "	&lt;h2> App Error &lt;/h2>&lt;p> There has been an error processing your Request &lt;/p>&lt;p> Internal Error.. &lt;/p>",</span>
<span style='color:#696969; '>	"cc": ["</span><span style='color:#7144c4; '>bob@bob.com</span><span style='color:#696969; '>", "</span><span style='color:#7144c4; '>tim@corporate.com</span><span style='color:#696969; '>"]</span>
<span style='color:#696969; '>}</span>
</pre>
