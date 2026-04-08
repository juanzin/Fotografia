import { Component, OnDestroy, OnInit } from '@angular/core';
import { PhotoRequestsService } from '../../../data/photo-requests.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy{

  private photos: any[];

  constructor(private photoRequests: PhotoRequestsService) {
    this.photos = [];
  }


  loadPhotos() {
    this.photoRequests.getPhotos().subscribe({
      next: (data) => {
        this.photos = data;
        console.log(data);
      },
      error: (err) => {
        console.error('Error loading photos', err);
      }
    });
  }

  public ngOnInit(): void {
    // this.loadPhotos();
  }

  public ngOnDestroy(): void {
    
  }

}
