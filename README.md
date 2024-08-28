# DotNetris
DotNetris is a windows forms application centered around the famous genre: tile matching or puzzle games. 

### There are Three Modes; Easy, Normal, and Hard. 
- Easy mode is where the pieces drop at 1 second with a .2 scaling.
- Normal mode is where the pieces drop at 0.5 secons with a .5 scaling
- Hard mode is where the pieces are drop at 0.25 seconds with a 1x scaling.

The goal is to match the pieces where you fill a row and it disappears once filled. 

The Point system is: 1 row = 100 points, 2 rows = 300 points, and 3 rows = 600 points. 

We have implemented features such as a Server, Local Multiplayer, a settings menu, a profile menu, single player, along with being able to login/regester to save your scores. 

We used Entity Framework, MSSQL (Microsoft SQL Server) for the database, and Windows Forms Application, using the Software VS 2022 or Visual Studio 2022. 
- https://azure.microsoft.com/en-us/products/azure-sql/database/?ef_id=_k_72e90c625fbe1973f03c6aacd8498d7c_k_&OCID=AIDcmm5edswduu_SEM__k_72e90c625fbe1973f03c6aacd8498d7c_k_&msclkid=72e90c625fbe1973f03c6aacd8498d7c -MSSQL
- https://visualstudio.microsoft.com/vs/ -VS 2022
- https://learn.microsoft.com/en-us/aspnet/entity-framework - Entity Framework

# How to Run the Server
To run the server, you must launch the 'DotNetris.Server.exe' executable from the command line. 
> [!NOTE]
> You do not need to run any migration commands, as the migrations are applied automatically on server start.

Arguments: 
* `--Host <HOSTNAME>`: **Required**. Hostname to listen to.
* `--Port <PORT>`: **Required**. Port to listen on.
* `--Password <PASSWORD>`: Password to use for connections. Sets security level to Medium.
* `--Cert <PATH>`: Path to a PKCS#7X509Certificate to use. Sets security level to High (TLS).
* `--DB <CONNECTION STRING>`: **Required**. Connection String for the MSSQL database.
