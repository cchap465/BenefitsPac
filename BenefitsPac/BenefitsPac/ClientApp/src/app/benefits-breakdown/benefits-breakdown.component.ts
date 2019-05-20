import { BenefitsBreakdown } from './../shared/models/benefits-breakdown';
import { BenefitsService } from './../shared/services/benefits.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-benefits-breakdown',
  templateUrl: './benefits-breakdown.component.html',
  styleUrls: ['./benefits-breakdown.component.css']
})
export class BenefitsBreakdownComponent implements OnInit {
  benefitsBreakdown = new BenefitsBreakdown();

  constructor(private route: ActivatedRoute,
    private benefitsService: BenefitsService) { }

  ngOnInit() {
    this.getBenefitsBreakdown();
  }

  getBenefitsBreakdown() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.benefitsService.getBenefitsBreakDown(id)
      .subscribe(benefitsBreakdown => {
        this.benefitsBreakdown = benefitsBreakdown;
      });
  }
}
