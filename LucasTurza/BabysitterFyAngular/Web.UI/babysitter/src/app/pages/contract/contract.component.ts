import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs';
import { LoginService } from '../login/services/login.service';
import { Profile } from '../profiles/interfaces/profile.interface';
import { MessageService } from '../profiles/services/message.service';
import { ProfileService } from '../profiles/services/profile.service';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.scss']
})
export class ContractComponent implements OnInit {
  id!: number;
  profile!: Profile;
  hours = 0;
  workDays = 0;
  total = 0;
  errorMessage = false;
  isLoading = false;
  messageSent = false;
  canMonday = false;
  canTuesday = false;
  canWednesday= false;
  canThursday = false;
  canFriday = false;
  canSaturday = false;
  canSunday = false;
  dayArray: string[] = [];

  constructor(private loginSvc: LoginService, private router: Router, private messageSvc: MessageService, private profileSvc: ProfileService) { }

  ngOnInit(): void {
    if(this.loginSvc.getRole() != 'Parent'){
      this.router.navigate(['./profiles']);
    }
    this.id = this.messageSvc.getId();
    if(this.id == null){
      this.router.navigate(['/profiles']);
    }else{
      this.profileSvc.getProfileById(this.id)
      .pipe(
        tap( (profile: Profile) => {
          this.profile = profile,
          profile.workTime.split(/[,]/).forEach(x => this.dayArray.push(x)),
          this.checkDays()
        })
      )
      .subscribe();
    }
  
  }

  checkDays(){
    console.log(this.dayArray, "AAAAAA")  
    this.dayArray.forEach(x => {
      if(this.dayArray.includes('Monday')){
        this.canMonday = true;
      }
      if(this.dayArray.includes('Tuesday')){
        this.canTuesday = true;
      }
      if(this.dayArray.includes('Wednesday')){
        this.canWednesday = true;
      }
      if(this.dayArray.includes('Thursday')){
        this.canThursday = true;
      }
      if(this.dayArray.includes('Friday')){
        this.canFriday= true;
      }
      if(this.dayArray.includes('Saturday')){
        this.canSaturday = true;
      }
      if(this.dayArray.includes('Sunday')){
        this.canSunday = true;
      }
    })
  }

  addDay($event:any){
    
    if($event.source._checked == true){
      this.workDays += 1;
    }else{
      this.workDays -= 1;
    }
    console.log(this.workDays);
  }

  addHours($event:any){
    this.hours = $event.target.value;
    console.log(this.hours);
  }

  calculateTotal(babysitterPrice:number){
    this.errorMessage = false;
    
    if(this.workDays == 0 || this.hours > 24 || this.hours <= 0){
      this.errorMessage = true;
      this.total = 0;
    }else{
      this.total = (this.hours * this.workDays) * babysitterPrice;
    }
  }

  simulateSend(){
    this.isLoading = true;
    setTimeout(() => {
      this.isLoading = false;
      this.messageSent = true;
      setTimeout(() => {
        this.router.navigate(['./profiles'])
      }, 4000);
    }, 3000);
  }
}
