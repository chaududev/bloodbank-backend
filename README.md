<div class="panel-body">
    <div class="content-row">
        <h3>Getting Started</h3>
        <div class="row">
            <div class="col-md-12">
                <div class="docs-article docs--start" id="Install">
                    <h3>Install</h3>
                    <ul class="item__infos">
                        <li>Clone the repo: <code>git clone https://github.com/chauuduu/BloodBankWeb</code></li>
                        <li>Create database in MSSQL: <code>create database BloodBankDB </code> and configure in <code>appsetting.json</code> if you want</li>
                        <li>Install database: <code>cd Insfrastructure </code> and  <code>dotnet ef database update</code> </li>
                        <li>Run project: <code>dotnet run</code></li>
                    </ul>
                </div>

                <!-- What's included
                ================================================== -->
                <div class="docs-article docs--start" id="included">
                    <h3>Folder Structure</h3>
                    <h4>Apply</h4>
                    <ul class="item__infos">
                        <li>Domain Driver Design</li>
                        <li>Onion Structure (Domain, Application, Infruscture, UI)</li>
                        <li>Api /swagger</li>
                        <li>Entity FrameWork, Linq, Generic, Automapper, JWToken, Authenication,...</li>
                    </ul>
<pre><code class="bash">
BloodBankWeb
├──domain    # model containing all entities, enum, base, value object,...
│  ├── entity 
│  ├── enum  
│  ├── valueobject  
└──└── base   
│
│──insfrucstrure    # storage database, migration, handle and directly interact with database     
│  ├── data
│  ├── migrations
│  ├── irepository
└──└── repository
│
│──application    #handle business logic, and interact with the database through the repository layer
│  ├── iservice
└──└── service
│
│──ui
│  ├── viewsmodel 
│  ├── apicontroller
│  ├── areas
│  ├── controllers
│  ├── mapper
│  ├── views
└──└── wwwroot   #include css,js, fonts, lib, uploads
</code></pre>
                </div>
                <!-- CSS/SASS
                ================================================== -->

                <div class="docs-article docs--start" id="download">
                    <h3>Download</h3>
                    <p>You can download project by zip</p>
                    <p><a class="btn btn-primary" href="https://github.com/chauuduu/BloodBankWeb/archive/main.zip">Download Project</a></p>
                </div>
                <div class="docs-article docs--start" id="Install">
                    <h3>Customize / Modify / Workflow</h3>
                    <div class="alert alert-success col-md-10">
                        <code>dotnet run</code> will monitor any changes to sass, css and js files and automatically combine, minify and clean all files to
                        <b>wwwroot/css/site.min.css</b> and <b>wwwroot/js/site.min.js</b>
                        <br class="clearfix"><br>
                    </div>
                    <div class="clearfix"></div>
                    <h4>CSS FILES</h4>
                    <p>Add your own css rules under <b>wwwroot/css/site.min.css</b></p>
                    <h4>JS FILES</h4>
                    <p>Add your javascript codes to <b>wwwroot/js/site.min.js.</b></p>
                    <h4>JQUERY</h4>
                    <p>link : <b>https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.4/jquery.min.js</b></p>
                    <h4>DEVEXPRESS</h4>
                    <p>link : <b>https://cdnjs.cloudflare.com/ajax/libs/devextreme/22.2.4/js/dx.all.js</b></p>

                </div>
                <!-- Color Picker
                ================================================== -->

                <div class="docs-article docs--start" id="licensing">
                    <h3>Credits</h3>
                    <p>Code by <a href="https://github.com/chauuduu">Châu Du</a></p>
                </div>
                <!-- Licensing
                ================================================== -->

            </div>


        </div>
    </div>
</div><!-- panel body -->
