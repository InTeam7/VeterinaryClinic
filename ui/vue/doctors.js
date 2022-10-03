const doctors={template:`
<nav class="navbar bg-light">
                <div class="container-fluid">
                    <div class="navbar-brand"></div>
                    <div class="ui search">
                    <div class="ui icon input">
                      <input class="prompt" type="text" placeholder="Поиск">
                      <i class="search icon"></i>
                    </div>
                    <div class="results" data-bs-toggle="modal"
                    data-bs-target="#detailModal"></div>
                  </div>
                </div>
</nav>
<div>
    <button type="button"
        class="btn btn-outline-success m-2 fload-end"
        data-bs-toggle="modal"
        data-bs-target="#detailModal"
        @click="addClick()">
        Добавить
    </button>
</div>

<table class="table table-hover  table-striped">
<thead>
    <tr>
        <th>
            ФИО
        </th>
        <th>
            Номер телефона
        </th>
        <th>
            Специальность
        </th>
        <th>
            
        </th>
    </tr>
</thead>
<tbody>
    <tr v-for="doc in doctors">
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(doc)">{{doc.name}}</td>
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(doc)">{{doc.phoneNumber}}</td>
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(doc)">{{doc.speciality}}</td>
        <td>
        <div class="d-flex justify-content-end">
        <button type="button" class="btn btn-outline-danger" @click="deleteClick(doc.id)"><i class="times icon"></i>Удалить</button>
        </div>
        </td>
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
                      <input type="text" class="form-control" id="validationDefault01" v-model="DocName" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault02" class="form-label">Номер Телефона</label>
                      <input type="text" data-masked="" data-inputmask="'mask': '+ 7 (999) 999-99-99'" class="form-control" id="validationDefault02" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault03" class="form-label">Специальность</label>
                      <input type="text" class="form-control" id="validationDefault03" v-model="DocSpeciality" required>
                    </div>
                    <div class="col-md-4">
                         <select class="selectpicker" multiple aria-label="size 3 select example" title="Выберите услуги">
                         <option v-for="service in services" :value = "service.id">
                         {{service.title}}
                         </option>
                        </select>
                    </div>
                    <div class="col-md-4 ms-auto d-flex justify-content-end">
                    <button type="button" @click="provideServicesClick()"
                    v-if="DocId!=0" class="btn btn-outline-info" data-bs-dismiss="modal" data-bs-toggle="modal"
                    data-bs-target="#ServicesModal">
                    Список оказанных услуг
                    </button>
                    </div>
                    
                    
                    <hr style="color:rgb(31, 40, 51, 0.8);">
                    <div class="col-12">
                    <button type="submit" @click="updateClick()"
                    v-if="DocId!=0" class="btn btn-primary" >
                    Обновить
                    </button>
                    <button type="submit" @click="createClick()"
                    v-if="DocId==0" class="btn btn-primary">
                    Добавить
                    </button>
                    </div>
                </form>
            </div>
            
        </div>
    </div>
</div>

<div class="modal fade" id="ServicesModal" tabindex="-1"
    aria-labelledby="ServicesModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            
            <div class="modal-body">
            <table class="table  table-bordered border-dark">
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
        services:[],
        docDetail: null,
        doctors:[],
        modalTitle:"",
        DocName:"",
        DocId:0,
        DocSpeciality:0,
        DocServices:[],
        provideServices:[]
        
    }
},
methods:{
refreshData(){
    axios.get(variables.API_URL+"Doctor")
    .then((response)=>{
        this.doctors=response.data;
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
    axios.get(variables.API_URL+"ClinicService")
        .then((response)=>{
            this.services=response.data;
        })
        .catch(err=>{
            alert(err.response.data.message)
        });
        
  },
 
  addClick(){
    this.modalTitle="Добавить Врача";
    this.DocId=0;
    this.DocSpeciality= "";
    this.DocName="";
    this.DocServices = 0;
    $("#validationDefault02").inputmask("setvalue", "");
    $('.selectpicker').selectpicker('deselectAll');
    $('.selectpicker').selectpicker('render');
    $('.selectpicker').selectpicker('refresh');    
},
createClick(){
    axios.post(variables.API_URL+"Doctor",{
        name: this.DocName,
        phoneNumber: $("#validationDefault02").val(),
        speciality: this.DocSpeciality,
        serviceIds: $('.selectpicker').val()
    })
    .then((response)=>{
        this.refreshData();
        $('#detailModal').modal('toggle');
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
},

  detailClick(doc){
    this.modalTitle="Подробнее";
    this.DocId = doc.id;
    $('.selectpicker').selectpicker('render');
    $('.selectpicker').selectpicker('refresh');
    
    axios.get(variables.API_URL+"Doctor/id",{
        params:{
            id: doc.id
        }
    })
    .then((response)=>{ 
        this.docDetail=response.data;
        $("#validationDefault02").inputmask("setvalue", this.docDetail.phoneNumber);
        this.DocName=this.docDetail.name;
        this.DocSpeciality = this.docDetail.speciality;
        this.DocServices = this.docDetail.services;
        let arr = [];
        this.DocServices.forEach(element => {
            arr.push(element.id.toString());
        });
        $('.selectpicker').selectpicker('val', arr);
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
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

  provideServicesClick(){
    axios.get(variables.API_URL+"ProvideService/docId",{
        params:{
            id: this.DocId
        }
    })
    .then((response)=>{
        let arr=[]
        response.data.forEach(element=>{
            element.date = this.formatDate(new Date(element.date));
            arr.push(element)
        })
        this.provideServices=arr;
        
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
  },
  updateClick(){
    axios.put(variables.API_URL+"Doctor/"+this.DocId,{
        name: this.DocName,
        phoneNumber: $("#validationDefault02").val(),
        speciality: this.DocSpeciality,
        serviceIds: $('.selectpicker').val()
    })
    .then((response)=>{
        this.refreshData();
        $('#detailModal').modal('toggle');
    })
    .catch(err=>{
        alert(err.response.data.message)
    });
    },
    sideBarClick(){
        var btns = document.getElementsByClassName("navigation-list-item");
            for (var i = 0; i < btns.length; i++) {
                var current = document.getElementsByClassName("active");
                if (current.length > 0) { 
                    current[0].className = current[0].className.replace("active", "");
                }
                $('#doctors').addClass('active');
            
        }
      },
    deleteClick(id){
        if(!confirm("Вы уверены?")){
            return;
        }
        axios.delete(variables.API_URL+"Doctor/"+id)
        .then((response)=>{
            this.refreshData();
        })
        .catch(err=>{
            alert(err.response.data.message)
        });
    }
    
},



  mounted:function(){
    this.refreshData();
    this.sideBarClick();
    $('.ui.search')
    .search({
      apiSettings: {
        url: 'http://localhost:5000/api/Doctor/name?name={query}'
      },
      fields: {
        title : 'name'
      },
      showNoResults:false,
      minCharacters : 1,
      onSelect: function(result,response){
        this.detailClick(result);
      }.bind(this)

    });
    $("#validationDefault02").inputmask();
    $("table").colResizable();

}
    
    
}