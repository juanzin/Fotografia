import { Component, OnDestroy, OnInit } from '@angular/core';
import { PhotographerRequestsService } from '../../../data/photographer-requests.service';

@Component({
  selector: 'app-phographer-manager',
  templateUrl: './phographer-manager.component.html',
  styleUrl: './phographer-manager.component.css'
})
export class PhographerManagerComponent implements OnInit, OnDestroy {
  
  private photographerId: number;
  public photographerInfo: any;
  
  constructor(private photographerRequest: PhotographerRequestsService) {
    this.photographerId = photographerRequest.getPhotographerId();
    this.photographerInfo = null;

  }


  getPhotographerInfo() {
     this.photographerRequest.getPhotographerInfo(this.photographerId).subscribe({
      next: (data) => {
        this.photographerInfo = data;
        console.log("phographer info: ", this.photographerInfo);
      },
      error: (err) => {
        console.error('Error loading productos', err);
      }
    });
  }

  ngOnInit(): void {
    this.getPhotographerInfo();
  }

  ngOnDestroy(): void {
    
  }
}
