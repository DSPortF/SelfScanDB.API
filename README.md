## SelfScanDB.API

Our hypothetical company provides self-checkout systems that allow retail customers to scan and pay for items independently, reducing wait times.  

Our internal helpdesk has been using in-house software but we have recently entered into a helpdesk contract with OracSync, who provide a comprehensive and customisable ticket management solution.  

OracSync's customisations provide for generic text fields, but there is no validation against our customer database (ScannerDB). In order to prevent data entry errors they will create an extension which calls an API into ScannerDB to return information on accounts, shops and kiosks, and to update a table with basic ticketing information which is still used by some of our other internal systems.  

This project is that API. ScannerDB is hosted on our internal systems so the API will be deployed to our DMZ.  


### Endpoints


#### /OracSync  
Returns a list of accounts  
"Accounts":[  
\{  
	"AccountName": "Blank",  
	"AccountGuid": " -GUID- "  
\},  
\{  
	"AccountName": "Giraffe Ladieswear",  
	"AccountGuid": " -GUID- "  
\}  
]  

#### Test Accounts:  
Blank  
Giraffe Ladieswear  
Old Look  
Clever Menswear  
Maljanvier  
Previous  
KE Sports  
Tertiark  
Sparks & Spanners  
VL Minn  

Account IDs: for the API, use GUIDs so that the real IDs are unguessable. The DB uses normal integral IDs of course but the API should not expose them.


#### /OracSync/\{AccountGuid\}  
List shops for that account  

"Shops": [  
\{  
	"ShopCode": 51,  
	"ShopName": "Giraffe - Macclesfield"  
\},  
\{  
	"ShopCode": 86,  
	"ShopName": "Giraffe - Liverpool Central"  
\}  
]  


#### /OracSync/ShopDetails/\{AccountGuid\}/\{ShopID\}  
Returns details of the shop and its device names  

"ShopDetails":  
\{  
	"ShopCode": 51,  
	"ShopName": "Giraffe - Macclesfield",  
	"ShopAddress": "427 Castle Street, Macclesfield",  
	"DeviceNames": ["Device1","Device2"]  
\}  

#### /OracSync/DeviceList/\{AccountGuid\}/\{ShopID\}  
Returns the properties for the devices at a shop  

"DeviceList": [  
\{  
	"DeviceName": "Device1",  
	"DeviceType": "DevType1",  
	"LastContact": "2025-05-13 10:35:22",  
	"DeviceSerial": " -random- "  
\},  
\{  
	"DeviceName": "Device2",  
	"DeviceType": "DevType2",  
	"LastContact": "2025-05-13 10:34:59",  
	"DeviceSerial": " -random- "  
\}  
]  

#### /OracSync/NewTicket/\{AccountGuid\}/\{ShopCode\}/\{TicketNumber\}  
Takes a list of devices: "DeviceNames": ["DeviceA","DeviceB"]  
Creates a new ticket on our internal system linking the ticket number with the relevant details.  
This must only be called on creation of a new ticket.  

#### /OracSync/Update/\{TicketNumber\}/\{Status\}  
Updates the ticket status on our internal system.  
