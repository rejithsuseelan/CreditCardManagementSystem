import { Component, ViewEncapsulation } from "@angular/core";

@Component({
  selector: "my-timeline",
  templateUrl: "./timeline.component.html",
  styleUrls: ["./timeline.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class TimelineComponent {
  timeLine = [
    {
      year: "2015",
      detail:
        "Lorem ipsum dolor sit amet, quo ei simul congue exerci, ad nec admodum perfecto mnesarchum, vim ea mazim fierent detracto. Ea quis iuvaret expetendis his, te elit voluptua dignissim per, habeo iusto primis ea eam.",
    },
    {
      year: "2016",
      detail:
        "Lorem ipsum dolor sit amet, quo ei simul congue exerci, ad nec admodum perfecto mnesarchum, vim ea mazim fierent detracto. Ea quis iuvaret expetendis his, te elit voluptua dignissim per, habeo iusto primis ea eam.",
    },
    {
      year: "2017",
      detail:
        "Lorem ipsum dolor sit amet, quo ei simul congue exerci, ad nec admodum perfecto mnesarchum, vim ea mazim fierent detracto. Ea quis iuvaret expetendis his, te elit voluptua dignissim per, habeo iusto primis ea eam.",
    },
    {
      year: "2018",
      detail:
        "Lorem ipsum dolor sit amet, quo ei simul congue exerci, ad nec admodum perfecto mnesarchum, vim ea mazim fierent detracto. Ea quis iuvaret expetendis his, te elit voluptua dignissim per, habeo iusto primis ea eam.",
    },
    {
      year: "2019",
      detail:
        "Lorem ipsum dolor sit amet, quo ei simul congue exerci, ad nec admodum perfecto mnesarchum, vim ea mazim fierent detracto. Ea quis iuvaret expetendis his, te elit voluptua dignissim per, habeo iusto primis ea eam.",
    },
  ];
}
