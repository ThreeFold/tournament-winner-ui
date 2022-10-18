export default class Community {
    id: number;
    name: string;
    slug?: string;
    description?: string;

    constructor(id: number, name: string, slug?: string, description?: string){
        this.id = id;
        this.name = name;
        this.slug = slug;
        this.description = description;
    }
    
    get communityIdentifier(): string {
        return this.slug ?? this.name ?? this.id;
    }
}