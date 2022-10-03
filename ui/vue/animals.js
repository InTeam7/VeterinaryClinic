const animals={template:`
<nav class="navbar bg-light">
                <div class="container-fluid">
                    <div class="navbar-brand"></div>
                    <div class="ui icon input">
                      <input v-model="userinput" type="text" placeholder="Поиск" id="search" >
                      <i class="search icon"></i>
                    </div>
                </div>
</nav>
<div class="ui hidden divider"></div>

<table class="table table-hover table-striped">
<thead>
<tr>
    <th style="width:7%">
        Фото
    </th>
    <th>
        Кличка Животного
    </th>
    <th>
        Возраст
    </th>
    <th>
       Вид
    </th>
    <th>
        Пол
    </th>
</tr>
</thead>
<tbody>
    <tr v-for="animal in animals" data-bs-toggle="modal"
    data-bs-target="#detailModal" @click="detailClick(animal)">
        <td>
        <img :src="PhotoPath+animal.fileName" class="ui avatar image">
        </td>
        <td>{{animal.name}}</td>
        <td> {{animal.age}}</td>
        <td>{{animal.specie}}</td>
        <td>{{animal.gender}}</td>
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
                <div class="d-flex flex-row bd-highlight mb-3">
                    <div class="p-2 w-50 bd-highlight">
                        <div class="input-group mb-3">
                            <span class="input-group-text">Кличка</span>
                            <input type="text" class="form-control" v-model="AnimalName">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text">Пол</span>
                            <select class="form-select" v-model="Gender">
                                <option v-for="gender in genders">
                                {{gender}}
                                </option>
                            </select>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text">Вид</span>
                            <select class="form-select" v-model="Specie">
                                <option v-for="specie in species">
                                {{specie}}
                                </option>
                            </select>
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text">Возраст</span>
                            <input type="text" class="form-control" v-model="AnimalAge">
                        </div>
                        
                        <div class="input-group mb-3">
                            <span class="input-group-text">Имя хозяина</span>
                            <input readonly type="text" class="form-control" v-model="OwnerName">
                        </div>
                        
                        <div class="d-flex mb-3">
                            <div class="p-2">
                                <button type="button" @click="provideServicesClick()"
                                v-if="AnimalId!=0" class="btn btn-success" data-bs-dismiss="modal" data-bs-toggle="modal"
                                data-bs-target="#ServicesModal">
                                Мед Карта
                                </button>
                            </div>

                            <div class="ms-auto p-2">
                                <button type="button" @click="VaccineClick()"
                                v-if="AnimalId!=0" class="btn btn-warning " data-bs-dismiss="modal" data-bs-toggle="modal"
                                data-bs-target="#VaccineModal">
                                Карта прививок
                                </button>
                            </div>
                        </div>
                    </div>

                    <div class="p-2 w-50 bd-highlight">
                         <img :src="PhotoPath+PhotoFileName" class="ui fluid rounded image">
                        <input class="m-2" type="file" @change="imageUpload">
                    </div> 
                </div>
                <button type="button" @click="updateClick()"
                v-if="AnimalId!=0" class="btn btn-primary">
                Обновить
                </button>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="ServicesModal" tabindex="-1"
    aria-labelledby="ServicesModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-body">
            <table class="table table-bordered border-dark">
            <thead>
                <tr>
                    <th>
                        Кличка Животного
                    </th>
                    <th>
                        Наименование услуги
                    </th>
                    <th>
                        Имя Врача
                    </th>
                    <th>
                        Цена
                    </th>
                    <th>
                        Дата
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="provideService in provideServices">
                    <td>{{provideService.animalName}}</td>
                    <td>{{provideService.serviceName}}</td>
                    <td> {{provideService.doctorName}}</td>
                    <td>{{provideService.servicePrice}}</td>
                    <td>{{provideService.date}}</td>
                </tr>
            </tbody>
            </table>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="VaccineModal" tabindex="-1"
    aria-labelledby="VaccineModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-body">
            <table class="table table-bordered border-dark">
            <thead>
                <tr>
                    <th>
                        Наименование вакцины
                    </th>
                    <th>
                        Стоимость
                    </th>
                    <th>
                        Имя Врача
                    </th>
                    <th>
                        Дата
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="vaccine in vaccines">
                    <td>{{vaccine.title}}</td>
                    <td>{{vaccine.price}}</td>
                    <td> {{vaccine.doc}}</td>
                    <td>{{vaccine.date}}</td>
                </tr>
            </tbody>
            </table>
            </div>
        </div>
    </div>
</div>


`,
data(){
    return{
        animals:[],
        animalDetail: null,
        modalTitle:"",
        AnimalName:"",
        AnimalId:0,
        AnimalAge:0,
        OwnerName:"",
        provideServices:[],
        userinput:"",
        Specie:"",
        Gender:"",
        genders:[],
        species:[],
        vaccines:[],
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
            axios.get(variables.API_URL+"Animal/name",{
            params:{
                name: val
            }
        })
         .then((response)=>{
            let arr=[];
            response.data.forEach(element=>{
                if(element.fileName=="string"||element.photoFileName==""){
                    element.fileName = this.PhotoFileName
                }
                arr.push(element);
            })
            this.animals=arr;
        })
         .catch(err=>{
             alert(err.response.data.message)
        });
    }
  }
},

methods:{
refreshData(){
    axios.get(variables.API_URL+"Animal")
    .then((response)=>{
        let arr=[];
        response.data.forEach(element=>{
            if(element.fileName=="string"||element.photoFileName==""){
                element.fileName = this.PhotoFileName
            }
            arr.push(element);
        })
        this.animals=arr;
    })
    .catch(err=>{
        alert(err.response.data.message)
    });        
  },
 
  detailClick(animal){
    this.modalTitle="Подробнее";
    this.AnimalId = animal.id;
    
    axios.get(variables.API_URL+"Animal/id",{
        params:{
            id: animal.id
        }
    })
    .then((response)=>{ 
        this.animalDetail=response.data;
        this.AnimalName=this.animalDetail.name;
        this.AnimalAge = this.animalDetail.age;
        this.OwnerName = this.animalDetail.ownerName;
        this.genders = this.animalDetail.genderValues;
        this.species = this.animalDetail.specieValues;
        this.Specie = this.animalDetail.specie;
        this.Gender = this.animalDetail.gender;
        this.PhotoFileName = this.animalDetail.photoFileName;
        
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
  },


  provideServicesClick(){
    let arr=[]
    this.animalDetail.providerServices.forEach(element=>{
        element.date = this.formatDate(new Date(element.date));
        arr.push(element)
    })
    this.provideServices=arr;
  },
  padTo2Digits(num) {
    return num.toString().padStart(2, '0');
  },
  VaccineClick(){
    let vaccine={}
    let arr=[]
    this.animalDetail.providerServices.forEach(element=>{
        if(element.vaccinePrice>0){
            vaccine={
                price: element.vaccinePrice,
                date : this.formatDate(new Date(element.date)),
                doc : element.doctorName
            }
            this.animalDetail.vaccines.forEach(e=>{
                if(element.vaccineId==e.id){
                    vaccine['title'] = e.title;
                }
            })
            arr.push(vaccine);
        }
    })
    this.vaccines=arr;
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
            $('#animals').addClass('active');
        
    }
  },
  

  updateClick(){
    axios.put(variables.API_URL+"Animal/"+this.AnimalId,{
        name: this.AnimalName,
        age: this.AnimalAge,
        gender: this.Gender,
        specie: this.Specie,
        fileName: this.PhotoFileName
    })
    .then((response)=>{
        this.refreshData();
        $('#detailModal').modal('toggle');
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
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

}



}