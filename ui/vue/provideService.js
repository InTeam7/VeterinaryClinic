const provideService={template:`
<nav class="navbar bg-light">
                <div class="container-fluid">
                    <div class="navbar-brand"></div>
                    <div class="ui icon input">
                      <input v-model="userinput" type="text" placeholder="Поиск" id="search" >
                      <i class="search icon"></i>
                    </div>
                </div>
</nav>
<div>
    <button type="button"
        class="btn btn-outline-success m-2 fload-end"
        data-bs-toggle="modal"
        data-bs-target="#addModal"
        @click="addClick()">
        Оказать услугу
    </button>
</div>

<table class="table table-hover table-striped">
<thead>
    <tr>
        <th>
            Кличка Животного
        </th>
        <th>
            Наименование услуги
        </th>
        <th>
            Имя лечащего врача
        </th>
        <th>
            Стоимость услуги
        </th>
        <th>
            Дата
        </th>
    </tr>
</thead>
<tbody>
    <tr v-for="service in services" data-bs-toggle="modal"
    data-bs-target="#detailModal" @click="detailClick(service)">
        <td>{{service.animalName}}</td>
        <td>{{service.serviceName}}</td>
        <td>{{service.doctorName}}</td>
        <td>{{service.servicePrice}}</td>
        <td>{{service.date}}</td>
    </tr>
</tbody>
</table>



<div class="modal fade" id="detailModal" tabindex="-1"
    aria-labelledby="detailModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="detailModalLabel">{{modalTitle}}</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"
                aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <form class="row g-3">
                    <div class="col-md-4">
                      <label  class="form-label">Кличка животного</label>
                      <input readonly type="text" class="form-control" v-model="AnimalName">
                    </div>
                    <div class="col-md-2">
                      <label  class="form-label">Пол</label>
                      <input readonly type="text" class="form-control" v-model="AnimalGender">
                    </div>
                    <div class="col-md-2">
                      <label  class="form-label">Вид</label>
                      <input readonly type="text" class="form-control" v-model="AnimalSpecie">
                    </div>
                    <div class="col-md-4">
                      <label  class="form-label">Возраст животного</label>
                      <input readonly type="text" class="form-control" v-model="AnimalAge">
                    </div>
                    <div class="col-md-5">
                      <label  class="form-label">Имя хозяина</label>
                      <input readonly type="text" class="form-control" v-model="OwnerName">
                    </div>
                    <div class="col-md-5">
                      <label  class="form-label">Номер телефона клиента</label>
                      <input readonly type="text" class="form-control" v-model="OwnerPhone">
                    </div>

                    <div class="col-md-4">
                      <label  class="form-label">Имя лечащего врача</label>
                      <input readonly type="text" class="form-control"  v-model="DoctorName">
                    </div>
                    
                    <div class="col-md-4">
                      <label  class="form-label">Наименование услуги</label>
                      <input readonly type="text" class="form-control"  v-model="ServiceName">
                    </div>

                    <div class="col-md-4">
                      <label  class="form-label">Наименование вакцины</label>
                      <input readonly type="text" class="form-control"  v-model="VaccineName">
                    </div>

                    
                    <div class="col-md-4">
                      <label  class="form-label">Номер телефона врача</label>
                      <input readonly type="text" class="form-control"  v-model="DoctorPhone">
                    </div>
                    <div class="col-md-4">
                      <label  class="form-label">Цена</label>
                      <input readonly type="text" class="form-control"  v-model="Price">
                    </div>
                    <div class="col-md-4">
                      <label  class="form-label">Дата</label>
                      <input readonly type="text" class="form-control"  v-model="ServiceDate">
                    </div>
                    <div class="col-md-4">
                      <label  class="form-label">Анамнез</label>
                      <textarea readonly type="text" class="form-control"  v-model="Anamnesis"></textarea>
                    </div>
                    <div class="col-md-4">
                      <label  class="form-label">Диагноз</label>
                      <textarea readonly type="text" class="form-control"  v-model="Diagnosis"></textarea>
                    </div>
                    
                </form>
            </div>
            
        </div>
    </div>
</div>
<div class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" id="addModal" tabindex="-1"
    aria-labelledby="addModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="detailModalLabel">Добавьте Клиента</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" 
                aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <form class="row g-3">
                    <div class="col-md-4">
                    <label for="validationDefault010" class="form-label">Имя Клиента</label>
                    <div class="ui fluid input">
                    <input type="text" class="form-control"  id="validationDefault010" v-model="OwnerName" required="">
                    </div>
                    </div>
                    <div class="col-md-4">
                        <label for="validationDefault02" class="form-label">Номер Телефона</label>
                        <div class="ui  search">
                        <div class="ui icon fluid input">
                          <input class="prompt" style="border-radius: 4px" id="validationDefault02" type="text" 
                          data-masked="" data-inputmask="'mask': '+ 7 (999) 999-99-99'" required="">
                        </div>
                        <div class="results"></div>
                        </div>
                        
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Email</label>
                        <div class="ui fluid input">
                             <input type="text" v-model="OwnerEmail">
                        </div>
                    </div>
                </form>
           </div> 
           <div class="modal-footer">
                <button type="submit"
                class="btn btn-success"
                data-bs-toggle="modal"
                data-bs-target="#addAnimalModal"
                @click="addClientClick()">
                    Продолжить
                </button>
            </div> 
            
        </div>
    </div>
</div>

<div class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" id="addAnimalModal" tabindex="-1"
    aria-labelledby="addAnimalModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="detailModalLabel">Добавьте Животоное</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" 
                aria-label="Close"></button>
            </div>
            <div class="modal-body">
            <div class="d-flex flex-row bd-highlight mb-3">
            <div class="p-2 w-50 bd-highlight">
                <div class="mb-3">
                    <label class="form-label">Кличка</label>
                    <div class="ui search" id = "AnimalSearch">
                        <div class="ui icon fluid input">
                          <input class="prompt" style="border-radius: 4px"  type="text" 
                           v-model="AnimalName">
                        </div>
                        <div class="results"></div>
                        </div>

                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text">Пол</span>
                    <select class="form-select" v-model="AnimalGender">
                        <option v-for="gender in genders">
                        {{gender}}
                        </option>
                    </select>
                </div>
                <div class="input-group  mb-3">
                    <span class="input-group-text">Вид</span>
                    <select class="form-select" v-model="AnimalSpecie">
                        <option v-for="specie in species">
                        {{specie}}
                        </option>
                    </select>
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text">Возраст</span>
                    <input type="text" class="form-control" v-model="AnimalAge">
                </div>
            </div>   
                

            <div class="p-2 w-50 bd-highlight">
                <img :src="PhotoPath+PhotoFileName" class="ui fluid rounded image">
                <input class="m-2" type="file" @change="imageUpload">
            </div> 
         </div>
         </div>
           
    
           <div class="modal-footer">
           <button type="button"
                class="btn btn-primary"
                data-bs-toggle="modal"
                data-bs-target="#addModal"
                @click="backClick()">
                    Назад
                </button>
                <button type="button"
                class="btn btn-success"
                data-bs-toggle="modal"
                data-bs-target="#addServiceModal"
                @click="addAnimalClick()">
                    Продолжить
                </button>
                
            </div> 
            
        </div>
    </div>
</div>

<div class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" id="addServiceModal" tabindex="-1"
    aria-labelledby="addServiceModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
        <div class="modal-header">
                <h5 class="modal-title" id="detailModalLabel">Добавьте Услугу</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" 
                aria-label="Close"></button>
            </div>
            <div class="modal-body">
            <form class="row g-3">
        <div class="col-md-4">
            <label  class="form-label">Выберите услугу</label>
            <select class="form-select"  @change="selectService" v-model="ServiceName">
                <option v-for="service in clinicServices" :value="service.id" :class="service.title">
                    {{service.title}}
                </option>
            </select>
        </div>
        <div v-if="clinicServiceId!=0" class="col-md-4">
            <label  class="form-label">Выберите врача</label>
             <select class="form-select"  @change="selectDoctor" v-model="DoctorName">
                <option v-for="doctor in doctors" :value = "doctor.id">
                    {{doctor.name}}
                </option>
             </select>
        </div>
        <div v-if="VaccineFlag!=0" class="col-md-4">
            <label  class="form-label">Выберите вакцину</label>
             <select class="form-select"  @change="selectVaccine" v-model="VaccineName">
                <option v-for="vaccine in vaccines" :value = "vaccine.id" >
                    {{vaccine.title}}
                </option>
             </select>
        </div>
        <div class="col-md-4" v-if="clinicServiceId!=0">
                <label  class="form-label">Анамнез</label>
                <textarea type="text" class="form-control"  v-model="Anamnesis"></textarea>
        </div>
        <div class="col-md-4" v-if="clinicServiceId!=0">
                <label  class="form-label">Диагноз</label>
                <textarea type="text" class="form-control"  v-model="Diagnosis"></textarea>
        </div>
    </form>
       </div> 
        
        
           
    
           <div class="modal-footer">
           <button type="button"
                class="btn btn-primary"
                data-bs-toggle="modal"
                data-bs-target="#addAnimalModal"
                @click="backAnimalClick()">
                    Назад
                </button>
                <button type="button"
                class="btn btn-success"
                data-bs-toggle="modal"
                data-bs-target="#createProvideService"
                @click="createProvServiceClick()">
                    Продолжить
                </button>
                
            </div> 
            
        </div>
    </div>
</div>

<div class="modal fade" id="createProvideService" tabindex="-1"
    aria-labelledby="createModalLabel" aria-hidden="true">
    <div class="modal-dialog  modal-xl">
        <div class="modal-content">
        <div class="modal-header">
                <h5 class="modal-title" id="detailModalLabel">Добавьте Животное</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"
                aria-label="Close"></button>
            </div>
            <div class="modal-body" id="element-to-print">
            <div class="d-flex flex-row bd-highlight mb-3">
            <div class="p-2 w-50 bd-highlight">
            <div class="mb-3">
                    <label class="form-label">Имя клиента</label>
                    <input type="text" readonly class="form-control"  v-model="OwnerName">
                </div>
                <div class="input-group mb-3">
                    <label class="input-group-text">Номер телефона</label>
                    <input type="text" readonly class="form-control"  v-model="OwnerPhone">
                </div>
                <div class="input-group  mb-3">
                    <label class="input-group-text">Email</label>
                    <input type="text" readonly class="form-control"  v-model="OwnerEmail">  
                </div>
                <div class="mb-3">
                    <label class="form-label">Кличка</label>
                    <input type="text" readonly class="form-control"  v-model="AnimalName">
                </div>
                <div class="input-group mb-3">
                    <label class="input-group-text">Пол</label>
                    <input type="text" readonly class="form-control"  v-model="AnimalGender">
                </div>
                <div class="input-group  mb-3">
                    <label class="input-group-text">Вид</label>
                    <input type="text" readonly class="form-control"  v-model="AnimalSpecie">  
                </div>
                <div class="input-group mb-3">
                    <label class="input-group-text">Возраст</label>
                    <input type="text" readonly class="form-control"  v-model="AnimalAge">
                </div>
            </div>   
                

            <div class="p-2 w-50 bd-highlight">
                <img :src="PhotoPath+PhotoFileName"  style="height:100%;width: 100%;" class="ui  rounded image">
            </div> 
         </div>



            <form class="row g-3">
        <div class="col-md-4">
            <label  class="form-label">Наименование услуги</label>
            <input type="text" readonly class="form-control"  v-model="ServiceNameVm">
            
        </div>
        <div  class="col-md-4">
            <label  class="form-label">ФИО врача</label>
            <input type="text" readonly class="form-control"  v-model="DoctorNameVm">
             
        </div>
        <div  class="col-md-4">
            <label  class="form-label">Наименование вакцины</label>
            <input type="text" readonly class="form-control"  v-model="VaccineNameVm">
             
        </div>
        <div class="col-md-6">
                <label  class="form-label">Анамнез</label>
                <textarea readonly type="text" class="form-control"  v-model="Anamnesis"></textarea>
        </div>
        <div class="col-md-6">
                <label  class="form-label">Диагноз</label>
                <textarea readonly type="text" class="form-control"  v-model="Diagnosis"></textarea>
        </div>
    </form>
       </div> 
        
        
           
    
           <div class="modal-footer">
           
                <button type="button"
                class="btn btn-success"
                @click="exportToPDF">
                    Распечатать
                </button>
                
            </div> 
            
        </div>
    </div>
</div>


`,
data(){
    return{
        services:[],
        clinicServices:[],
        doctors:[],
        vaccines:[],
        VaccineFlag:0,
        
        animals:[],
        genders:[],
        species:[],
        provideServiceDetail: null,
        modalTitle:"",

        AnimalName:"",
        AnimalGender:"",
        AnimalSpecie:"",
        AnimalAge:0,
        AnimalId:0,
        
        OwnerName:"",
        OwnerPhone:"",
        OwnerEmail:"",
        OwnerId:0,
        ownerAnimals:[],

        ProvideServiceId:0,
        ServiceName:"",
        ServiceNameVm:"",
        VaccineName:"",
        VaccineNameVm:"",
        clinicServiceId:0,
        vaccineId:null,

        DoctorName:"",
        DoctorNameVm:"",
        DoctorPhone:"",
        DoctorId:"",

        Price:0,
        ServiceDate:"",
        Anamnesis:"",
        Diagnosis:"",
        provideServices:[],
        userinput:"",
        userphone:"",
        PhotoFileName:"anonymous.jpeg",
        PhotoPath:variables.PHOTO_URL
        
    }
},
watch: {
    userinput: function(val, oldVal) {
        if(val===""){
            this.refreshData();
        }
        else{
            axios.get(variables.API_URL+"ProvideService/name",{
            params:{
                name: val
            }
        })
         .then((response)=>{
            let arr = [];
        response.data.forEach(element=>{
           element.date = this.formatDate(new Date(element.date));
           arr.push(element)
        })
        this.services=arr;
        this.genders = this.services[0].genderValues;
        this.species = this.services[0].specieValues;
        })
         .catch(err=>{
             alert(err.response.data.message)
        });
    }
  },

 
},
methods:{
refreshData(){
    axios.get(variables.API_URL+"ProvideService")
    .then((response)=>{
        let arr = [];
        response.data.providedServices.forEach(element=>{
           element.date = this.formatDate(new Date(element.date));
           arr.push(element)
        })
        this.services=arr;

        this.genders = response.data.genderValues;
        this.species = response.data.specieValues;
    })
    .catch(err=>{
        alert(err.response.data.message)
    });        
  },
 
  detailClick(service){
    this.modalTitle="Подробнее";
    this.ProvideServiceId = service.id;
    
    axios.get(variables.API_URL+"ProvideService/id",{
        params:{
            id: service.id
        }
    })
    .then((response)=>{ 
        this.provideServiceDetail=response.data;
        this.OwnerName=this.provideServiceDetail.ownerName;
        this.OwnerPhone = this.provideServiceDetail.ownerPhoneNumber;
        this.AnimalName = this.provideServiceDetail.animalName;
        this.AnimalAge = this.provideServiceDetail.animalAge;
        this.AnimalGender = this.provideServiceDetail.gender;
        this.AnimalSpecie = this.provideServiceDetail.specie;
        this.AnimalGender = this.provideServiceDetail.gender;
        this.ServiceName = this.provideServiceDetail.serviceName;
        this.DoctorName = this.provideServiceDetail.doctorName;
        this.DoctorPhone = this.provideServiceDetail.doctorPhoneNumber;
        this.Price = this.provideServiceDetail.price;
        this.ServiceDate = this.formatDate(new Date(this.provideServiceDetail.date));
        this.Anamnesis = this.provideServiceDetail.anamnesis;
        this.Diagnosis = this.provideServiceDetail.diagnosis;
        if(this.provideServiceDetail.vaccineId!=null){
            axios.get(variables.API_URL+"Vaccine/id",{
                params:{
                    id: this.provideServiceDetail.vaccineId
                }
            })
            .then((resp)=>{ 
                this.VaccineName = resp.data.title;
            });
        }
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
  },

  addClick(){
    
    this.clinicServices=[];
    this.doctors=[];
    this.vaccines=[];
    this.VaccineFlag=0;
    this.animals=[];
    this.provideServiceDetail= null;
    this.modalTitle="";
    this.AnimalName="";
    this.AnimalGender="";
    this.AnimalSpecie="";
    this.AnimalAge=0;
    this.AnimalId=0;
    this.OwnerName="";
    this.OwnerPhone="";
    this.OwnerEmail="";
    this.OwnerId=0;
    this.ownerAnimals=[];
    this.ProvideServiceId=0;
    this.ServiceName="";
    this.VaccineName="";
    this.ServiceNameVm="";
    this.VaccineNameVm="";
    this.clinicServiceId=0;
    this.vaccineId=null;
    this.DoctorName="";
    this.DoctorNameVm="";
    this.DoctorPhone="";
    this.DoctorId="";
    this.Price=0;
    this.ServiceDate="";
    this.Anamnesis="";
    this.Diagnosis="";
    this.provideServices=[];
    this.userinput="";
    this.userphone="";
    this.PhotoFileName="anonymous.jpeg";

},
addClientClick(){
    if(this.OwnerId!=0){
        axios.get(variables.API_URL+"Client/id",{
            params:{
                id: this.OwnerId
            }
        })
        .then((response)=>{
            if(response.data.phoneNumber===$("#validationDefault02").val()){
                axios.put(variables.API_URL+"Client/"+this.OwnerId,{
                    name: this.OwnerName,
                    email: this.OwnerEmail,
                    phoneNumber: $("#validationDefault02").val()
                })
                .then((response)=>{
                    $('#addModal').modal('toggle');
                })
            }
        })
    }
            else{
                axios.post(variables.API_URL+"Client",{
                    name: this.OwnerName,
                    phoneNumber: $("#validationDefault02").val(),
                    email: this.OwnerEmail
                })
                .then((response)=>{
                    this.OwnerId = response.data
                    $('#addModal').modal('toggle');
                });
            }
            
         
    

},
backClick(){
    $('#addAnimalModal').modal('toggle');
    
},

addAnimalClick(){

    if(this.AnimalId!=0){
        axios.put(variables.API_URL+"Animal/"+this.AnimalId,{
            name: this.AnimalName,
            age: this.AnimalAge,
            gender: this.AnimalGender,
            specie: this.AnimalSpecie,
            fileName: this.PhotoFileName
        })
        .then((response)=>{
            $('#addAnimalModal').modal('toggle');
        })
    }
    else{
        axios.post(variables.API_URL+"Animal",{
            name: this.AnimalName,
            age: this.AnimalAge,
            gender: this.AnimalGender,
            specie: this.AnimalSpecie,
            fileName: this.PhotoFileName,
            ownerId: this.OwnerId
        })
        .then((response)=>{
            this.AnimalId = response.data
            $('#addAnimalModal').modal('toggle');
        });
    }
    axios.get(variables.API_URL+"ClinicService")
    .then((response)=>{
        this.clinicServices = response.data;
    })
    
    

},
backAnimalClick(){
    $('#addServiceModal').modal('toggle');
},

selectService(e){
     this.VaccineFlag = 0;
     this.vaccineId=null;
     this.clinicServiceId = e.target.value;
     axios.get(variables.API_URL+"ClinicService/id",{
        params:{
            id: this.clinicServiceId
        }
    })
    .then((response)=>{ 
        let arr=[]
        response.data.doctors.forEach(element=>{
            if(element.isDeleted==false){
                arr.push(element)
            }
        })
        this.doctors = arr;
        if(response.data.title.toLowerCase().includes('вакц')){
            this.VaccineFlag = 1;
            axios.get(variables.API_URL+"Vaccine")
            .then((resp)=>{ 
                this.vaccines = resp.data;
            });
        }
        this.ServiceNameVm=response.data.title;

    })
},
selectVaccine(e){
    this.vaccineId = e.target.value;
    axios.get(variables.API_URL+"Vaccine/id",{
        params:{
            id: this.vaccineId
        }
    })
    .then((response)=>{ 
        this.VaccineNameVm = response.data.title
    })
},
selectDoctor(e){
    this.DoctorId = e.target.value;
    axios.get(variables.API_URL+"Doctor/id",{
        params:{
            id: this.DoctorId 
        }
    })
    .then((response)=>{ 
        this.DoctorNameVm = response.data.name
    })
},
createProvServiceClick(){
    axios.post(variables.API_URL+"ProvideService",{
        animalId: this.AnimalId,
        serviceId: this.clinicServiceId,
        doctorId: this.DoctorId,
        diagnosis: this.Diagnosis,
        ananmnesis: this.Anamnesis,
        vaccineId: this.vaccineId
    })
    .then((response)=>{
        $('#addServiceModal').modal('toggle');
        //this.refreshData();
    });
},
exportToPDF() {
    
    var element = document.getElementById('element-to-print');
var opt = {
  margin:       1,
  filename:     'myfile.pdf',
  image:        { type: 'jpeg', quality: 0.99 },
  html2canvas:  { 
    useCORS: true,
    allowTaint: true },
  jsPDF:        { unit: 'in', format: 'letter', orientation: 'portrait' }
};
html2pdf().from(element).set(opt).save();
this.refreshData();
  },





  padTo2Digits(num) {
    return num.toString().padStart(2, '0');
  },
  
 formatDate(date) {
    return (
        [
            this.padTo2Digits(date.getHours()),
            this.padTo2Digits(date.getMinutes()),
            this.padTo2Digits(date.getSeconds()),
        ].join(':') +
          ' ' +
       [
        this.padTo2Digits(date.getMonth() + 1),
        this.padTo2Digits(date.getDate()),
        date.getFullYear(),
       ].join('/')
    );
  },
  sideBarClick(){
    var btns = document.getElementsByClassName("navigation-list-item");
        for (var i = 0; i < btns.length; i++) {
            var current = document.getElementsByClassName("active");
            if (current.length > 0) { 
                current[0].className = current[0].className.replace("active", "");
            }
            $('#provideService').addClass('active');
        
    }
  },
  imageUpload(event){
    let formData=new FormData();
    formData.append('file',event.target.files[0]);
    axios.post(
        variables.API_URL+"Animal/savefile",
        formData)
        .then((response)=>{
            this.PhotoFileName=response.data;
        });
}
   
},



  mounted:function(){
    this.refreshData();
    this.sideBarClick();
    $("table").colResizable();
    $("#validationDefault02").inputmask({
         "oncomplete": function()
         {
             this.OwnerPhone = $("#validationDefault02").val()
         } 
    });
    
    $('.ui.search')
    .search({
      apiSettings: {
        url: 'http://localhost:5000/api/Client/searchString?searchString={query}'
      },
      fields: {
        title : 'name'
      },
      showNoResults:false,
      minCharacters : 1,
      cache: false,
      onSelect: function(result,response){
        this.OwnerName = result.name;
        this.OwnerPhone = result.phoneNumber;
        this.OwnerEmail = result.email;
        this.OwnerId = result.id;
        $("#validationDefault02").inputmask("setvalue", result.phoneNumber);
      }.bind(this)
    });
    $('#AnimalSearch')
    .search({
      apiSettings: {
        url: 'http://localhost:5000/api/Animal/ByOwnerId',
        method: 'POST',
        beforeXHR: (xhr) => {
            xhr.setRequestHeader('Content-Type', 'application/json','charset = utf-8');
        },
        beforeSend: (settings) => {
            settings.data = JSON.stringify({
                
                id: this.OwnerId,
                name: 'opt',
            })
            return settings
        }
      },
      fields: {
        title : 'name'
      },
      showNoResults:false,
      minCharacters : 0,
      cache: false,
      onSelect: function(result,response){
        this.AnimalAge = result.age;
        this.PhotoFileName = result.fileName;
        this.AnimalGender = result.gender;
        this.AnimalSpecie = result.specie;
        this.AnimalName = result.name;
        this.AnimalId = result.id;
      }.bind(this),
      onResults: function(result){
        this.ownerAnimals = result;
      }.bind(this)
      
    });

      
    
    //var d = document.getElementById('validationDefault02')
	//d.onkeyup = function() {
     //   str = this.value.replace(/[^0-9]/g, '');
      //  if(str||str.length!=0){
       //     console.log(str)
        //}
	    
	//}
          

}



}