# ImageFilter
This repository contains descriptions of algorithms for image processing such as noise
reduction with different padding types such as mirror padding. The source codes of the projects in the
C# programming language implementing the algorithms are included on the book’s
companion web site. 

## Mean Filter ( average filter)
The nonweighted averaging filter calculates the mean gray value in a gliding square
window of W × W pixels where W is the width and height of a square gliding window.
The greater the window size W, the stronger the suppression of Gaussian noise: The filter
decreases the noise by the factor W. The value W is usually an odd integer W = 2 × h + 1
for the sake of symmetry.

## Median Filter
A median filter sorts the intensities of colors in the gliding window and
replaces the intensity in the middle of the gliding window by the intensity staying in the
middle of the sorted sequence. Median filters can also be used for suppressing impulse
noise or salt-and-pepper noise.

## Sigma Filter
The sigma filter reduces noise in the same way as the averaging filter: by averaging many
gray values or colors. The idea of the sigma filter is averaging only those intensities
(i.e., gray values or intensities of color channels) in a gliding window that differ from
the intensity of the central pixel by no more than a fixed parameter called tolerance.
According to this idea, the sigma filter reduces the Gaussian noise and retains the edges
in the image not blurred.
