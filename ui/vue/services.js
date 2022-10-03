const services={template:`
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
        data-bs-target="#detailModal"
        @click="addClick()">
        Добавить
    </button>
</div>

<table class="table table-hover table-striped">
<thead>
    <tr>
        <th>
            Наименование
        </th>
        <th>
            Цена
        </th>
        <th>
            
        </th>
    </tr>
</thead>
<tbody>
    <tr v-for="service in services">
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(service)">{{service.title}}</td>
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(service)">{{service.price}}</td>
        <td>
        <div class="d-flex justify-content-end">
        <button type="button" class="btn btn-outline-danger" @click="deleteClick(service.id)"><i class="times icon"></i>Удалить</button>
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
                      <label for="validationDefault01" class="form-label">Наименование</label>
                      <input type="text" class="form-control" id="validationDefault01" v-model="ServiceTitle" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault02" class="form-label">Цена</label>
                      <input type="text" class="form-control" id="validationDefault02" v-model="ServicePrice" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault03" class="form-label">Описание</label>
                      <textarea type="text" class="form-control" id="validationDefault03" v-model="ServiceDescription" required></textarea>
                    </div>
                    <div class="col-md-4">
                         <select class="selectpicker" multiple aria-label="size 3 select example" title="Выберите врачей">
                         <option v-for="doc in doctors" :value = "doc.id">
                         {{doc.name}}
                         </option>
                        </select>
                    </div>

                    <div class="col-md-4 ms-auto d-flex justify-content-end">
                    <button type="button" @click="provideServicesClick()"
                    v-if="ServiceId!=0" class="btn btn-outline-info" data-bs-dismiss="modal" data-bs-toggle="modal"
                    data-bs-target="#ServicesModal">
                    Список оказанных услуг
                    </button>
                    </div>
                   
                    <hr style="color:rgb(31, 40, 51, 0.8);">
                    <div class="col-12">
                    <button type="submit" @click="updateClick()"
                    v-if="ServiceId!=0" class="btn btn-primary">
                    Обновить
                    </button>
                    <button type="submit" @click="createClick()"
                    v-if="ServiceId==0" class="btn btn-primary">
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
        serviceDetail: null,
        services:[],
        doctors:[],
        modalTitle:"",
        ServiceTitle:"",
        ServiceId:0,
        ServicePrice:0,
        ServiceDescription:"",
        ServiceDoc:[],
        provideServices:[],
        userinput: ""
        
    }
},
watch: {
    userinput: function(val, oldVal) {
        if(val===""){
            this.refreshData();
        }
        else{
            axios.get(variables.API_URL+"ClinicService/title",{
            params:{
                 title: val
            }
        })
         .then((response)=>{
             this.services = response.data;
        })
         .catch(err=>{
             alert(err.response.data.message)
        });
    }
  }
},
methods:{
    refreshData(){
        axios.get(variables.API_URL+"ClinicService")
        .then((response)=>{
            this.services=response.data;
        })
        .catch(err=>{
          alert(err.response.data.message)
      });

      axios.get(variables.API_URL+"Doctor")
         .then((response)=>{
             this.doctors=response.data;
        })
      .catch(err=>{
         alert(err.response.data.message)
     });

      },
      addClick(){
        this.modalTitle="Добавить Услугу";
        this.ServiceId=0;
        this.ServicePrice= 0;
        this.ServiceTitle="";
        this.ServiceDescription = "";
        $('.selectpicker').selectpicker('deselectAll');
        $('.selectpicker').selectpicker('render');
        $('.selectpicker').selectpicker('refresh');  
      
    },
    createClick(){
        axios.post(variables.API_URL+"ClinicService",{
            title: this.ServiceTitle,
            price: this.ServicePrice,
            description: this.ServiceDescription,
            doctorIds: $('.selectpicker').val()
        })
        .then((response)=>{
            this.refreshData();
            $('#detailModal').modal('toggle');
        })
        .catch(err=>{
            alert(err.response.data.message)
        });
    },
    


      detailClick(service){
        this.modalTitle="Подробнее";
        this.ServiceId = service.id;
        $('.selectpicker').selectpicker('render');
        $('.selectpicker').selectpicker('refresh');
        axios.get(variables.API_URL+"ClinicService/id",{
            params:{
                id: service.id
            }
        })
        .then((response)=>{ 
            this.serviceDetail=response.data;
            this.ServiceTitle=this.serviceDetail.title;
            this.ServiceDescription = this.serviceDetail.description;
            this.ServicePrice = this.serviceDetail.price;
            this.ServiceDoc = this.serviceDetail.doctors;
            let arr = [];
            this.ServiceDoc.forEach(element => {
                arr.push(element.id.toString());
            });
            $('.selectpicker').selectpicker('val', arr);
        })
        .catch(err=>{
          alert(err.response.data.message)
      });
        
      },
    
      provideServicesClick(){
            let arr=[]
            this.serviceDetail.providedServices.forEach(element=>{
                element.date = this.formatDate(new Date(element.date));
                arr.push(element)
            })
            this.provideServices=arr;
      },
      updateClick(){
        axios.put(variables.API_URL+"ClinicService/"+this.ServiceId,{
            title: this.ServiceTitle,
            description: this.ServiceDescription,
            price: this.ServicePrice,
            doctorIds: $('.selectpicker').val()
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
                    $('#services').addClass('active');
                
            }
          },
        deleteClick(id){
            if(!confirm("Вы уверены?")){
                return;
            }
            axios.delete(variables.API_URL+"ClinicService/"+id)
            .then((response)=>{
                this.refreshData();
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

    },

    mounted:function(){
        this.refreshData();
        this.sideBarClick();
        $("table").colResizable();
         }
}
