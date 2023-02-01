export default interface Community {
    id: number;
    name: string;
    slug: string;
    description?: string;
    ownerUserId: string;
    insertDate: Date;
}