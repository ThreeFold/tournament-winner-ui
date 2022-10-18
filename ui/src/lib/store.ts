import { readable } from "svelte/store";
import Community from "./models/community";

export const community = readable(new Community(
    1234,
    "Gem State Smash",
    "gss",
    `

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur dignissim ipsum sed rhoncus rhoncus. Quisque neque dolor, luctus at orci nec, ullamcorper condimentum mi. Aenean bibendum quis metus non finibus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Suspendisse facilisis condimentum felis, pretium tristique orci aliquet eget. Nunc ut turpis id purus laoreet condimentum sit amet ut nulla. Phasellus vel eleifend ipsum. Integer vel sapien tempor felis fringilla aliquet. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc non viverra tortor, vel aliquam nisi. Nullam erat dolor, eleifend in ante sed, bibendum posuere felis. Nulla orci ligula, tincidunt eget ultricies nec, vestibulum at odio. Curabitur justo eros, fringilla sed ipsum sed, egestas volutpat sem. Donec ut diam ultricies, ornare ante ac, auctor justo.

Nunc tincidunt metus mi, id tempor erat egestas nec. Proin suscipit scelerisque tellus sit amet aliquet. Praesent diam ante, vestibulum id metus maximus, porta tincidunt ligula. Donec eget neque libero. Aliquam erat volutpat. Quisque ultrices pharetra efficitur. Suspendisse potenti. Proin ultricies ligula libero, ac porttitor mauris molestie vel. Praesent porttitor diam odio, eu tempor turpis ultricies nec. Duis convallis nibh id nibh venenatis, id pharetra neque fermentum. Donec vitae faucibus elit. Nulla facilisi. Fusce facilisis leo risus, non suscipit neque malesuada at. Sed facilisis in arcu nec tincidunt. Vivamus placerat, dolor eget ultrices egestas, metus arcu pulvinar ipsum, et placerat tortor nibh at nulla. Maecenas bibendum fringilla neque, eu aliquet mauris suscipit quis.

Etiam euismod hendrerit nulla, vitae malesuada nisi lacinia scelerisque. Praesent ut fermentum dolor. Mauris bibendum ante ut ornare commodo. Mauris a elit sit amet odio imperdiet consequat. In mi enim, sagittis eget nisi eget, condimentum luctus erat. Quisque ipsum ante, consectetur a diam non, scelerisque tincidunt nulla. Sed varius lectus nulla, mattis vulputate risus vestibulum vitae.

Phasellus sem dolor, maximus a dui ac, sodales maximus arcu. Praesent pretium tempor velit quis malesuada. Sed vulputate mi in suscipit maximus. Suspendisse iaculis ligula ut ligula luctus auctor. Phasellus non diam id metus ultricies sagittis. Curabitur suscipit in tortor iaculis posuere. Curabitur fringilla arcu a diam aliquam laoreet. Quisque sit amet accumsan lectus. Suspendisse potenti. Mauris sagittis augue augue, a iaculis erat tempus ac. Nulla sodales odio leo, sit amet vestibulum purus sagittis quis. Aenean eget dui ultricies, consectetur felis id, dictum leo. Mauris euismod nisi ante.

Nam cursus felis neque, vitae ultricies est tincidunt nec. Mauris dictum, dolor a dapibus auctor, erat neque mattis mauris, sit amet eleifend risus lectus et augue. Suspendisse nec arcu in massa cursus tincidunt. Phasellus rhoncus augue ac lacus semper, eget finibus ligula venenatis. Nullam ultricies metus eu condimentum eleifend. Quisque nec dolor nec nisi ornare posuere. Donec libero nulla, ullamcorper laoreet dictum in, ornare et nisi. Donec nec posuere ante. Cras id vestibulum leo. Suspendisse et est sit amet nulla sodales fringilla a non mi. In id nulla id eros blandit tempus ut vitae lorem. Morbi odio tortor, efficitur eget dapibus vitae, bibendum et massa. Vestibulum pulvinar nisi et nisl viverra, sed egestas justo ultrices. Nunc vel dapibus nisl. `

));