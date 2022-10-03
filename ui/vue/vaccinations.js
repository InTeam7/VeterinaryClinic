const vaccinations={template:`
<nav class="navbar bg-light">
                <div class="container-fluid">
                    <div class="navbar-brand"></div>
                    <div class="ui icon input">
                      <input v-model="userinput" id="search" type="text" placeholder="Поиск">
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
            Количество
        </th>
        <th>
            Цена
        </th>
        <th>
            
        </th>
    </tr>
</thead>
<tbody>
    <tr v-for="vac in vaccines">
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(vac)">{{vac.title}}</td>
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(vac)">{{vac.count}}</td>
        <td data-bs-toggle="modal"
        data-bs-target="#detailModal" @click="detailClick(vac)">{{vac.price}}</td>
        <td>
        <div class="d-flex justify-content-end">
        <button type="button" class="btn btn-outline-danger" @click="deleteClick(vac.id)"><i class="times icon"></i>Удалить</button>
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
                      <label for="validationDefault01" class="form-label">Название</label>
                      <input type="text" class="form-control" id="validationDefault01" v-model="VaccineTitle" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault02" class="form-label">Цена</label>
                      <input type="text" class="form-control" id="validationDefault02" v-model="VaccinePrice" required>
                    </div>
                    <div class="col-md-4">
                      <label for="validationDefault02" class="form-label">Количество</label>
                      <input type="text" class="form-control" id="validationDefault02" v-model="VaccineCount" required>
                    </div>
                    <div class="col-md-5">
                      <label for="validationDefault03" class="form-label">Описание</label>
                      <textarea type="text" class="form-control" id="validationDefault03" v-model="VaccineDescription" required></textarea>
                    </div>
                    <div class="col-md-3">
                      <label for="validationDefault04" class="form-label">Изготовлен</label>
                      <div class="ui calendar" id="date">
                        <div class="ui input left icon">
                            <i class="calendar icon"></i>
                            <input type="text" placeholder="Date">
                        </div>
                      </div>
                    </div>
                    <div class="col-md-3">
                      <label for="validationDefault04" class="form-label">Годен до</label>
                      <div class="ui calendar" id="expDate">
                        <div class="ui input left icon">
                            <i class="calendar icon"></i>
                            <input type="text" placeholder="Date">
                        </div>
                      </div>
                    </div>
                    <hr style="color:rgb(31, 40, 51, 0.8);">
                    <div class="col-12">
                    <button type="submit" @click="updateClick()"
                    v-if="VaccineId!=0" class="btn btn-primary">
                    Обновить
                    </button>
                    <button type="submit" @click="createClick()"
                    v-if="VaccineId==0" class="btn btn-primary">
                    Добавить
                    </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

`,

data(){
    return{
        vaccineDetail: null,
        vaccines:[],
        modalTitle:"",
        VaccineTitle:"",
        VaccineCount:0,
        VaccineId:0,
        VaccinePrice:0,
        VaccineDescription:"",
        userinput: ""
        
    }
},
watch: {
  userinput: function(val, oldVal) {
      if(val===""){
          this.refreshData();
      }
      else{
        console.log(val)
          axios.get(variables.API_URL+"Vaccine/title",{
          params:{
               title: val
          }
      })
       .then((response)=>{
           this.vaccines = response.data;
      })
       .catch(err=>{
           alert(err.response.data.message)
      });
   } 
  }
},
methods:{
refreshData(){
    axios.get(variables.API_URL+"Vaccine")
    .then((response)=>{
        this.vaccines=response.data;
    })
    .catch(err=>{
      alert(err.response.data.message)
  });
  },
 
  addClick(){
    this.modalTitle="Добавить Вакцину";
    this.VaccineId=0;
    this.VaccineCount= 0;
    this.VaccineTitle="";
    this.VaccinePrice = 0;
    this.VaccineDescription = "";
    $('#date').calendar('clear'); 
    $('#expDate').calendar('clear'); 
},
createClick(){
    axios.post(variables.API_URL+"Vaccine",{
        title: this.VaccineTitle,
        price: this.VaccinePrice,
        description: this.VaccineDescription,
        count: this.VaccineCount,
        expirationDate: this.isoDateWithoutTimeZone($('#expDate').calendar('get date')),
        date: this.isoDateWithoutTimeZone($('#date').calendar('get date'))
    })
    .then((response)=>{
        this.refreshData();
        $('#detailModal').modal('toggle');
    })
    .catch(err=>{
      alert(err.response.data.message)
  });
},

  detailClick(vac){
    this.modalTitle="Подробнее";
    this.VaccineId = vac.id;
    axios.get(variables.API_URL+"Vaccine/id",{
        params:{
            id: vac.id
        }
    })
    .then((response)=>{ 
        this.vaccineDetail=response.data;
        this.VaccineCount=this.vaccineDetail.count;
        this.VaccineTitle=this.vaccineDetail.title;
        this.VaccinePrice = this.vaccineDetail.price;
        this.VaccineDescription = this.vaccineDetail.description;
        $('#date').calendar('set date', this.vaccineDetail.date, updateInput = true, fireChange = false); 
        $('#expDate').calendar('set date', this.vaccineDetail.expirationDate, updateInput = true, fireChange = false); 
    })
    .catch(err=>{
      alert(err.response.data.message)
  });
    
  },
   isoDateWithoutTimeZone(date) {
    if (date == null) return date;
    var timestamp = date.getTime() - date.getTimezoneOffset() * 60000;
    var correctDate = new Date(timestamp);
    return correctDate.toISOString();
  },

  updateClick(){
    axios.put(variables.API_URL+"Vaccine/"+this.VaccineId,{
        title: this.VaccineTitle,
        price: this.VaccinePrice,
        description: this.VaccineDescription,
        count: this.VaccineCount,
        expirationDate: this.isoDateWithoutTimeZone($('#expDate').calendar('get date')),
        date: this.isoDateWithoutTimeZone($('#date').calendar('get date'))
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
              $('#vaccinations').addClass('active');
          
      }
    },


    deleteClick(id){
        if(!confirm("Вы уверены?")){
            return;
        }
        axios.delete(variables.API_URL+"Vaccine/"+id)
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
    $('.ui.calendar')
    .calendar({
      monthFirst: false,
      type: 'date',
      formatter: {
        date: function (date, settings) {
          if (!date) return '';
          var day = date.getDate();
          var month = date.getMonth()+1;
          var year = date.getFullYear();
          return day + '/' + month + '/' + year;
        }
      },
      text: {
        days: ['П', 'В', 'С', 'Ч', 'П', 'С', 'В'],
        months: ['Январь', 'Ферваль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
        monthsShort: ['Jan', 'Fev', 'Mar', 'Avr', 'Mai', 'Juin', 'Juil', 'Aou', 'Sep', 'Oct', 'Nov', 'Dec'],
      }
      
    });
    $("table").colResizable();
   
}


}
