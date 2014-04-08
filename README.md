dschelper
=========

Web api with helper functions for powershell DSC. The idea is to install this on the DSC Server

Required config:
in web.config, set the setting named "MofFolder" to the path on the pull server where all the mof guid files reside.

Functions:

HostToGuid: A guest (DSC client) can ask the server for its guid, based on its servername:
Invoke-RestMethod -Uri "http://dscserver/api/HostToGuid?HostName=$($env:computername)" -contenttype "application/json"
