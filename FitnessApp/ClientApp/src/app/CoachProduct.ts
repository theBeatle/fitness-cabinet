export class CoachProduct{
  constructor(
    public Id?: number,
    public Country?: string,
    public State?: string,
    public City?: string,
    public Street?: string,
    public Building?: string,
    public Longitude?: string,
    public Latitude?: string,
    public SportKind?: string,
    public TrainingName?: string,
    public PlaceName?: string,
    public WorkShedule?: string,
    public IsSimplePlace?: boolean,
    public Price?: string,
    public Description?: string,
    public PlaceDescription?: string,
    public Photo?: string
  ) { }
}
