void main() {
       print 2 .< 3 .< 4;
       print 3 .< 2 .== 2;
       print 3 .> 2 .== 2;
       print (3 .> 2 .== 2) == (3 .> 1 .== 1);
       print (3 .> 2 .== 2) == 1;

       print -200 .< 3 .< 2400;
       print 2+2 .< 2/2 .== 1;
       print (1 .== 1 .== 2-1) .== 1 .<= 3;
       print (2 .== 2 .== 2) .<= 3 .!= 1;
       print -2 .!= 2 .!= 0;
}