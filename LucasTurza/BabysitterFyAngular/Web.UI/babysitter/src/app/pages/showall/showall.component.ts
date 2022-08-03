import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs';
import { Profile } from '../profiles/interfaces/profile.interface';
import { MessageService } from '../profiles/services/message.service';
import { ProfileService } from '../profiles/services/profile.service';

@Component({
  selector: 'app-showall',
  templateUrl: './showall.component.html',
  styleUrls: ['./showall.component.scss']
})
export class ShowallComponent implements OnInit {

  constructor(private ProfileSvc: ProfileService, private router: Router, private messageSvc: MessageService) { }

  profiles!: Profile[]

  async ngOnInit(): Promise<any> {
    return this.ProfileSvc.getProfiles()
    .pipe(
      tap( (profiles: Profile[]) => {this.profiles = profiles, console.log(profiles)})
    )
    .subscribe();
    
  }

  goToProfile(id:number):void{
    this.router.navigate(['./profile']);
    this.messageSvc.saveId(id);
    console.log(id);
  }

  actualYear = 2022;
  convertToAge(date:string):number{
    let dates = new Date(date)
    let years = dates.getFullYear()
    return Math.abs(years-this.actualYear)
  }

}
