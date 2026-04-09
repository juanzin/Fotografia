import { Component, OnDestroy, OnInit } from '@angular/core';
import { PhotographerRequestsService } from '../../../data/photographer-requests.service';
import { DataStorageService } from '../../../data/data-storage.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent implements OnInit, OnDestroy{

  private photographerId: number;
  public photographerInfo: any;
  public username: string;
  constructor(
      private photographerRequest: PhotographerRequestsService,
      private dataStorage: DataStorageService) {
        this.photographerId = dataStorage.getPhotographerId();
        this.photographerInfo = {};
        this.username = "";

  }

  getPhotographerInfo() {
     this.photographerRequest.getPhotographerInfo(this.photographerId).subscribe({
      next: (data) => {
        if(data.length > 0) {
          this.photographerInfo = data[0];
          this.username = data[0].name + " " + data[0].materno;
        } else {
          console.error("photographer not found");
        }
      },
      error: (err) => {
        console.error('Error getting user info', err);
      }
    });
  }

  ngOnInit(): void {
    this.getPhotographerInfo();
  }

  ngOnDestroy(): void {
    
  }
}
