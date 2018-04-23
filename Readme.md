# How to implement a custom clusterer


This example demonstrates how to implement a custom clusterer.


<h3>Description</h3>

To do this, design a class implementing&nbsp;the&nbsp;<strong>IClusterer&nbsp;</strong>interface.&nbsp;<br />The&nbsp;owner's O<strong>nClustered</strong>&nbsp;method should be called to notify the owner adapter that clustering is finished.<br />Note that for a newly created collection of cluster representatives, the owner is specified as parameter of the constructor.

<br/>


