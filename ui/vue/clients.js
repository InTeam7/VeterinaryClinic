const clients={template:`
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
        <th>
            ФИО
        </th>
        <th>
            Email
        </th>
        <th>
            Номер телефона
        </th>
    </tr>
</thead>
<tbody>
    <tr v-for="client in clients" data-bs-toggle="modal"
    data-bs-target="#detailModal" @click="detailClick(client)">
        <td>{{client.name}}</td>
        <td>{{client.email}}</td>
        <td>{{client.phoneNumber}}</td>
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
                      <label for="validationDefault01" class="form-label">ФИО</label>
                      <input type="text" class="form-control" id="validationDefault01" v-model="ClientName" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault02" class="form-label">Email</label>
                      <input type="text" class="form-control" id="validationDefault02" v-model="ClientEmail" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault03" class="form-label">Номер Телефона</label>
                      <input type="text" data-masked="" data-inputmask="'mask': '+ 7 (999) 999-99-99'" class="form-control" id="validationDefault03" required>
                    </div>

                    
                    
                    <table class="table table-striped ">
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
                        <tr v-for="animal in animals">
                            <td>
                            <img :src="PhotoPath+animal.photoFileName" class="ui avatar image">
                            </td>
                            <td>{{animal.name}}</td>
                            <td> {{animal.age}}</td>
                            <td>{{animal.specie}}</td>
                            <td>{{animal.gender}}</td>
                        </tr>
                    </tbody>
                    </table>
                    <div class="col-md-4 ms-auto d-flex justify-content-end">
                    <button type="button" @click="provideServicesClick()"
                    v-if="ClientId!=0" class="btn btn-outline-info" data-bs-dismiss="modal" data-bs-toggle="modal"
                    data-bs-target="#ServicesModal">
                    Список оказанных услуг
                    </button>
                    </div>
                    
                    
                   
                    <hr style="color:rgb(31, 40, 51, 0.8);">
                    <div class="col-12">
                    <button type="submit" @click="updateClick()"
                    v-if="ClientId!=0" class="btn btn-primary">
                    Обновить
                    </button>
                    </div>
                </form>
            </div>
            <div class="modal-footer">
            <p>Сумма оплаченных услуг: <mark>{{ ClientPurchases }}</mark></p>
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


`,
data(){
    return{
        clients:[],
        animals:[],
        clientDetail: null,
        modalTitle:"",
        ClientName:"",
        ClientId:0,
        ClientEmail:"",
        ClientPurchases:"",
        provideServices:[],
        userinput:"",
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
            axios.get(variables.API_URL+"Client/searchString",{
            params:{
                searchString: val
            }
        })
         .then((response)=>{
             this.clients = response.data;
        })
         .catch(err=>{
             alert(err.response.data.message)
        });
    }
  }
},
methods:{
refreshData(){
    axios.get(variables.API_URL+"Client")
    .then((response)=>{
        this.clients=response.data;
    })
    .catch(err=>{
        alert(err.response.data.message)
    });        
  },
 
  detailClick(client){
    this.modalTitle="Подробнее";
    this.ClientId = client.id;
    
    axios.get(variables.API_URL+"Client/id",{
        params:{
            id: client.id
        }
    })
    .then((response)=>{ 
        let arr=[];
        this.clientDetail=response.data;
        $("#validationDefault03").inputmask("setvalue", this.clientDetail.phoneNumber);
        this.ClientName=this.clientDetail.name;
        this.ClientEmail = this.clientDetail.email;
        this.ClientPurchases = this.clientDetail.purchases;
        this.clientDetail.animals.forEach(element=>{
            if(element.photoFileName=="string"||element.photoFileName==""){
                element.photoFileName=this.PhotoFileName
            }
            arr.push(element);
        })
        this.animals = arr

    })
    .catch(err=>{
        alert(err.response.data.message)
    });
  },


  provideServicesClick(){
    let arr=[]
    this.clientDetail.animals.forEach(element=>{
        element.providerServices.forEach(e=>{
            e.date = this.formatDate(new Date(e.date));
            arr.push(e)
        }) 
    })
    this.provideServices=arr;
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
            $('#clients').addClass('active');
        
    }
  },
  

  updateClick(){
    axios.put(variables.API_URL+"Client/"+this.ClientId,{
        name: this.ClientName,
        phoneNumber: $("#validationDefault03").val(),
        email: this.ClientEmail
    })
    .then((response)=>{
        this.refreshData();
        $('#detailModal').modal('toggle');
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
    }
   
},



  mounted:function(){
    this.refreshData();
    this.sideBarClick();
    $("#validationDefault03").inputmask();
    $("table").colResizable();

}



}