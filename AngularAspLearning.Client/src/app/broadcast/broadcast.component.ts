import { Component, OnInit } from '@angular/core';
import { BroadcastService } from './broadcast.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-broadcast',
  templateUrl: './broadcast.component.html',
  styleUrls: ['./broadcast.component.scss'],
})
export class BroadcastComponent implements OnInit {
  public result: Observable<any | null>;

  constructor(private service: BroadcastService) {
    this.result = service.result; 
  }

  ngOnInit(): void {
    this.service.startConnection();
    this.service.addDataListeners();
  }
}
